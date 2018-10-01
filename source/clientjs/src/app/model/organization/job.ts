import { BaseEntity } from '../common/baseentity'
import { JobFrequency } from './jobfrequency';

export class Job extends BaseEntity {
    applicationName: string;
    endTime: Date;
    isEnabled: boolean;
    isSiteJob: boolean;
    site: string;
    startDate: Date;
    startTime: Date;
    frequency: JobFrequency;
    workflowName: string;

    constructor(){
        super();
        this.isEnabled = false;
        this.frequency = new JobFrequency();
        this.startDate =  new Date(Date.now());
    }
}