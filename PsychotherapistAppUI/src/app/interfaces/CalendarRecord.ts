import { FrequenceEnum } from "./frequenceEnum";
import { Psychotherapist } from "./psychotherapist";

export interface CalendarRecord {
    id: number,
    description: string,
    startTime: string,
    endTime: string,
    frequency: FrequenceEnum,
    roomNumber: number,
    psychotherapist: Psychotherapist,
    psychotherapistId: number,
}


