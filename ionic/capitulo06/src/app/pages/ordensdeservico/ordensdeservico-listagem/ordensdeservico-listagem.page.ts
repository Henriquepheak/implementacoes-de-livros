import { Component, OnInit, ViewChild } from '@angular/core';
import { IonList, MenuController } from '@ionic/angular';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { DatabaseService } from 'src/app/services/database.service';
import { databaseName } from 'src/app/services/database.statements';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-ordensdeservico-listagem',
  templateUrl: './ordensdeservico-listagem.page.html',
  styleUrls: ['./ordensdeservico-listagem.page.scss'],
})
export class OrdensdeservicoListagemPage implements OnInit {

  public ordensDeServico: void | OrdemDeServico[] = [];
  @ViewChild('slidingList') slidingList: IonList;

  constructor(
    private ordensdeservicoService: OrdensDeServicoService,
    private menu: MenuController,
    private databaseService: DatabaseService
  ) {
  }

  async ngOnInit() {
    console.log('Teste OrdensdeservicoListagemPage: ' + (this.databaseService.isConnection(databaseName).then(function (result) { console.log('result' + result.result) })));


  }

  async ionViewWillEnter() {
    console.log('ionViewWillEnter');
    // const db = await this._databaseService.retrieveConnection(databaseName)
    // console.log('Deu na listagem');

    const oss = await this.ordensdeservicoService.getAll();
    this.ordensDeServico = oss;
  }
}
