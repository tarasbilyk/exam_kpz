import { CalendarRecord } from "./CalendarRecord";

export interface Psychotherapist {
    id: number,
    name: string,
    surname: string,
    email: string,
    calendarRecords: CalendarRecord[]
}
