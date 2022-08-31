import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [];
  public filteredEvents: any = [];

  widthImage = 200;
  marginImage  = 2;
  hideImage  = false;
  private _listFilter = '';

  public get listFilter(): string{
    return this._listFilter;
  }

  public set listFilter(value: string){
    this._listFilter = value;
    this.filteredEvents = this.listFilter ? this.listFiltered(this.listFilter) : this.events;
  }

  listFiltered(filterBy: string): any{
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: any) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1
      || event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEvents();
  }

  showImage(){
    this.hideImage = !this.hideImage;
  }

  public getEvents(): void {
    this.http.get('https://localhost:5001/Events').subscribe(
      response =>{
        this.events = response,
        this.filteredEvents = this.events
      },
      error => console.log(error)
    );

    this.events
  }

}

