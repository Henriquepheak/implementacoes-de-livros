import { Injectable } from '@angular/core';
import { Peca } from '../models/peca.model';
import { Guid } from 'guid-typescript';
import { Storage } from '@ionic/storage-angular';

@Injectable({
    providedIn: 'root'
})
export class PecasService {

    constructor(
        private storage: Storage
    ) { }

    async update(peca: Peca) {
        await this.storage.create();
        if (peca.id.isEmpty()) {
            peca.id = Guid.create();
        }

        this.storage.set(peca.id.toString(), JSON.stringify(peca));
    }

    async getAll() {
        // tslint:disable-next-line:prefer-const
        let pecas: Peca[] = [];
        try {
            await this.storage.forEach((value: string, key: string) => {
                const peca: Peca = JSON.parse(value);
                pecas.push(peca);
            });
            return pecas;
        } catch (error) {
            return error;
        }
    }
}