import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef , PaginationChangedEvent,   GridApi, GridReadyEvent  } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { MotorQuotation } from 'src/shared/models/motor-quotation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    public paginationPageSize = 10;
    public rowData!: MotorQuotation[];
    private gridApi!: GridApi<MotorQuotation>;
    colDefs: ColDef[]=[{field: 'quotationNumber'},
    {field: 'policyOwner',filter:true,filterParams: {
      buttons: [ 'apply','reset'],
      closeOnApply:true
    }},
    {field: 'carMake',filter:true,filterParams: {
      buttons: [ 'apply','reset'],
      closeOnApply:true
    }},
    {field: 'yearOfMake'},
    {field: 'quotationStatus'},
    {field: 'creationDate', sortable:true}];

    title = 'SystemCars'; 
    filteredQuotations: MotorQuotation[] = [];
    searchText: string = '';
    sortedBy: string = '';
    currentPage: number = 1;
    pageSize: number = 10;


    @ViewChild(AgGridAngular) agGrid!: AgGridAngular;
    clearSeelection(){
      this.agGrid.api.deselectAll();
    }
    constructor(private http: HttpClient){}
    ngOnInit() {
       this.http.get<MotorQuotation[]>('http://localhost:7093/api/Vehicle/get-car-details?page=' + this.currentPage +'&pagesize=' + this.pageSize ).subscribe((data) => (this.rowData = data));
      }

}
