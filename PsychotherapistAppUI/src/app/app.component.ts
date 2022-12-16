import { Component, OnInit } from '@angular/core';
import { CalendarRecord } from './interfaces/CalendarRecord';
import { FrequenceEnum } from './interfaces/frequenceEnum';
import { Psychotherapist } from './interfaces/psychotherapist';
import { CalendarRecordService } from './services/calendar-record.service';
import { PsychotherapistService } from './services/psychotherapist.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  public psychotherapists!: Psychotherapist[];
  public calendarRecords!: CalendarRecord[];

  public selectedId!: number;

  public frequenceTypes = Object.values(FrequenceEnum).filter(x => !isNaN(Number(x)));

  public isEditMode: boolean = false;

  public createCalendarRecord: CalendarRecord = {
    id: 0,
    description: '',
    startTime: '',
    endTime: '',
    frequency: 0,
    roomNumber: 1,
    psychotherapist: null,
    psychotherapistId: 0
  };

  public updateCalendarRecord: CalendarRecord= {
    id: 0,
    description: '',
    startTime: '',
    endTime: '',
    frequency: 0,
    roomNumber: 1,
    psychotherapist: null,
    psychotherapistId: 0
  };

  constructor(
    private psychotherapistService: PsychotherapistService,
    private calendarRecordService: CalendarRecordService
  ) {

  }

  ngOnInit(): void {
    this.psychotherapistService.getPsychotherapists().subscribe((data) => {
      this.psychotherapists = data;
      this.selectedId = this.psychotherapists[0].id;
    });
    this.fillCalendarRecords();
  }

  addCalendarRecord(): void {
    console.log(this.createCalendarRecord);
    this.calendarRecordService.add(this.createCalendarRecord)
      .subscribe((data) => {
        this.fillCalendarRecords();
        this.clearCreateRecord();
      });
  }

  fillCalendarRecords() {
    this.calendarRecordService.getAll().subscribe((data) => this.calendarRecords = data);
  }

  clearCreateRecord() {
    this.createCalendarRecord = {
      id: 0,
      description: '',
      startTime: '',
      endTime: '',
      frequency: 0,
      roomNumber: 1,
      psychotherapist: null,
      psychotherapistId: 0
    }
  }

  deleteRecord(id: number){
    this.calendarRecordService.delete(id).subscribe((data) => this.fillCalendarRecords());
  }

  selectForEdit(calendarRecord: CalendarRecord){
    console.log(calendarRecord);
    // this.updateCalendarRecord = Object.create(calendarRecord);
    this.updateCalendarRecord.id = calendarRecord.id;
    this.updateCalendarRecord.description = calendarRecord.description;
    this.updateCalendarRecord.startTime = calendarRecord.startTime;
    this.updateCalendarRecord.endTime = calendarRecord.endTime;
    this.updateCalendarRecord.frequency = calendarRecord.frequency;
    this.updateCalendarRecord.psychotherapistId = calendarRecord.psychotherapistId;
    this.updateCalendarRecord.roomNumber = calendarRecord.roomNumber;
    console.log(this.updateCalendarRecord);
    this.isEditMode = true;
  }

  updateRecord(){
    this.isEditMode = false;
    console.log(this.updateCalendarRecord);
    this.calendarRecordService.update(this.updateCalendarRecord).subscribe((data) => this.fillCalendarRecords());
  }
}
