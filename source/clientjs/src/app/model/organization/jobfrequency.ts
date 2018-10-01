import { BaseEntity } from '../common/baseentity'

export class JobFrequency extends BaseEntity {
    days: number;
    hours: number;
    minutes: number;
    seconds: number;
}