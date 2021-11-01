import { fn } from '@angular/compiler/src/output/output_ast';
import { Injectable, SystemJsNgModuleLoader } from '@angular/core';
import { CapacitorSQLite, capSQLiteResult, SQLiteConnection, SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Capacitor } from '@capacitor/core';
import { Guid } from 'guid-typescript';
// import { ConsoleReporter } from 'jasmine';
import { createClientesTable, createOrdensDeServicoTable } from './database.statements';

@Injectable({
    providedIn: 'root'
})
export class DatabaseService {
    sqliteConnection: SQLiteConnection;
    platform: string;
    native: boolean = false;
    sqlitePlugin: any;

    async initializePlugin(): Promise<boolean> {
        return new Promise(resolve => {
            this.platform = Capacitor.getPlatform();
            if (this.platform === 'ios' || this.platform === 'android') this.native = true;
            this.sqlitePlugin = CapacitorSQLite;
            this.sqliteConnection = new SQLiteConnection(this.sqlitePlugin);
            resolve(true);
        });
    }

    async createConnection(database: string, encrypted: boolean,
        mode: string, version: number
    ): Promise<SQLiteDBConnection> {
        if (this.sqliteConnection != null) {
            let db: SQLiteDBConnection;
            try {
                db = await this.sqliteConnection.createConnection(
                    database, encrypted, mode, version);
                if (db != null) {
                    await this.createSchema(db);
                    return Promise.resolve(db);
                } else {
                    return Promise.reject(new Error(`Erro ao criar a conexão`));
                }
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Nenhuma conexão disponível para ${database}`));
        }
    }

    private async createSchema(db: SQLiteDBConnection): Promise<void> {
        await db.open();

        let createClienteSchemma: any = await db.execute(createClientesTable);
        let createOSSchemma: any = await db.execute(createOrdensDeServicoTable);

        await this.populateDatabase(db);

        if (createOSSchemma.changes.changes < 0 || createClienteSchemma.changes.changes < 0) {
            await db.close();
            return Promise.reject(new Error("Erro na criação das tabelas"));
        }

        await db.close();
        return Promise.resolve();
    }

    private async populateDatabase(db: SQLiteDBConnection): Promise<void> {
        const clienteID = Guid.create().toString();

        await this.populateClientes(db, clienteID);
        await this.populateOrdensDeServico(db, clienteID);

        return Promise.resolve();
    }

    private async populateClientes(db: SQLiteDBConnection, clienteID: String): Promise<void> {
        // db.open();
        console.log(1);
        let returnQuery = await db.query("select COUNT(clienteid) as qtdeClientes from clientes;");
        console.log(2);
        if (returnQuery.values[0].qtdeClientes > 0) {
            db.execute('DELETE FROM ordensdeservico;')
            db.execute('DELETE FROM clientes;')
        }
        if (returnQuery.values[0].qtdeClientes === 0) {
            console.log(3);
            let sqlcmd: string =
                "INSERT INTO clientes (clienteid, nome, email, telefone, renda) VALUES (?,?,?,?,?)";
            let values: Array<any> = [clienteID, 'Ambrózio', 'ambrozio@casadocodigo.com.br', '91234-5668', 123];

            let returnInsert = await db.run(sqlcmd, values,);
            console.log(4);
            if (returnInsert.changes < 0) {
                console.log(5);
                // db.close();
                return Promise.reject(new Error("Erro na inserção da clientes"));
            }
        }

        // db.close();
        console.log(6);
        return Promise.resolve();
    }

    private async populateOrdensDeServico(db: SQLiteDBConnection, clienteID: String): Promise<void> {
        console.log('clienteID ' + clienteID);

        let returnQuery = await db.query("select COUNT(ordemdeservicoid) as qtdeOS from ordensdeservico;");

        if (returnQuery.values[0].qtdeOS === 0) {
            let sqlcmd: string =
                "INSERT INTO ordensdeservico (ordemdeservicoid, clienteid, veiculo, dataehoraentrada, dataehoratermino) VALUES (?,?,?,?,?)";
            let values: Array<any> = [Guid.create().toString(), clienteID, 'ABC-1235', Date.now(), null];

            let returnInsert = await db.run(sqlcmd, values);
            if (returnInsert.changes < 0) {
                return Promise.reject(new Error("Erro na inserção da ordem de serviço"));
            }
        }

        return Promise.resolve();
    }

    async isConnection(database: string): Promise<capSQLiteResult> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.isConnection(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Sem conexão aberta`));
        }
    }

    async retrieveConnection(database: string):
        Promise<SQLiteDBConnection> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.retrieveConnection(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Sem conexão para ${database}`));
        }
    }


    async isDatabase(database: string): Promise<capSQLiteResult> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.isDatabase(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`A base de dados ${database} não existe`));
        }
    }

    async openConnection(database: string): Promise<SQLiteDBConnection> {
        if (this.sqliteConnection != null) {
            try {
                this.sqlitePlugin.open({ database: database });
                console.log(`Abriu a conexão com ${database} `);

                // if ((await this.sqlite.isConnection(database)).result) {
                const db: SQLiteDBConnection = await this.sqliteConnection.retrieveConnection(
                    database);
                console.log(`Recuperou a conexão com ${database} `);
                return Promise.resolve(db);
                // } else {
                //     console.log(`${ database } não é uma conexão`);
                // }
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Nenhuma conexão disponível para ${database} `));
        }
    }

    async deleteDatabase(db: SQLiteDBConnection): Promise<void> {
        try {
            let ret: any = await db.isExists();
            if (ret.result) {
                const dbName = db.getConnectionDBName();
                await db.delete();
                return Promise.resolve();
            } else {
                return Promise.resolve();
            }
        } catch (err) {
            return Promise.reject(err);
        }
    }
}