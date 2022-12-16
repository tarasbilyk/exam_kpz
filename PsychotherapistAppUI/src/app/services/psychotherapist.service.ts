import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Psychotherapist } from '../interfaces/psychotherapist';

@Injectable({
  providedIn: 'root'
})
export class PsychotherapistService {

  constructor(private httpClient: HttpClient) { }

  public getPsychotherapists(){
    return this.httpClient.get<Psychotherapist[]>("https://localhost:44322/api/psychotherapists");
  }
}
