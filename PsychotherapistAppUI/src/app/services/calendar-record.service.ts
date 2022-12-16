import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CalendarRecord } from '../interfaces/CalendarRecord';

@Injectable({
  providedIn: 'root'
})
export class CalendarRecordService {

  apiUrl:string = "https://localhost:44322/api/calendarRecords";

  constructor(private httpClient: HttpClient) { }

  public getAll(){
    return this.httpClient.get<CalendarRecord[]>(this.apiUrl);
  }

  public add(record: CalendarRecord){
    return this.httpClient.post<CalendarRecord>(this.apiUrl, record);
  }

  public delete(id: number){
    return this.httpClient.delete<any>(this.apiUrl + '/' + id);
  }

  public update(record: CalendarRecord){
    return this.httpClient.put<CalendarRecord>(this.apiUrl, record);
  }
}
