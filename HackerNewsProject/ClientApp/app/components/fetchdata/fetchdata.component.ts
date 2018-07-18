import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    styleUrls: ['fetchDataStyle.css'],
})
export class FetchDataComponent {
    public data: ObjectModel[] | undefined;
    //public data: WeatherForecast[];
    public title: string = "";

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        debugger;
        http.get(baseUrl + 'api/GetDataJson').subscribe(result => {
            this.data = result.json() as ObjectModel[];
        }, error => console.error(error));
    }
    


     LinkToTitle(title:any) {

    }
}

interface ObjectModel {
    by: string;
    title: string;
}
