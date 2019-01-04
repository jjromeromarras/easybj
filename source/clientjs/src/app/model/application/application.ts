import { BaseEntity } from '../common/baseentity';
import { Job } from '../organization/job';
import { Aggregate } from './aggregate/aggregate';
import { Entity } from './views/entity/entity';
import { Event } from './event/event';
import { FieldType } from './field/fieldtype';
import { Format } from './views/format/format';
import { MenuItem } from '../organization/menuitem';
import { Record } from './record/record';
import { RecordList } from './record/recordlist';
import { Relationship } from './relationship/relationship';
import { Report } from './report/report';
import { Resource } from '../resources/resource';
import { RFMenuItem } from '../organization/rfmenuitem';
import { SecGroup } from '../organization/secgroup';
import { Validator } from './views/validator/validator';
import { ViewGroup } from './views/viewgroups';
import { BindData } from './objstr';
import { Subscription } from './subscription/subscription';
import { List } from './list/list';
import { Dialog } from './dialogs/dialogs';


export class Application extends BaseEntity {
    activationDate: Date;
    jobs: Array<Job>;
    aggregates: Array<Aggregate>;
    dependingApplications: Array<string>;
    description: BindData;
    entities: Array<Entity>;
    events: Array<Event>;
    fieltypes: Array<FieldType>;
    formats: Array<Format>;
    imagesFolder: BindData;
    menuitems: Array<MenuItem>;
    onlineMode: boolean;
    records: Array<Record>;
    recordlists: Array<RecordList>;
    relationships: Array<Relationship>;
    reports: Array<Report>;
    resources: Array<Resource>;
    rfmenuitems: Array<RFMenuItem>;
    secgroups: Array<SecGroup>;
    dialogs: Array<Dialog>;
    subcriptions: Array<Subscription>;
    validators: Array<Validator>;
    versionId: string;
    viewgroups: Array<ViewGroup>;
    lists: Array<List>;

    // TODO: WF, VISTAS Y WFSTATION

    constructor() {
        super();
        this.jobs = new Array<Job>();
        this.aggregates = new Array<Aggregate>();
        this.dependingApplications = new Array<string>();
        this.entities = new Array<Entity>();
        this.events = new Array<Event>();
        this.fieltypes = new Array<FieldType>();
        this.formats = new Array<Format>();
        this.menuitems = new Array<MenuItem>();
        this.recordlists = new Array<RecordList>();
        this.records = new Array<Record>();
        this.relationships = new Array<Relationship>();
        this.reports = new Array<Report>();
        this.resources = new Array<Resource>();
        this.rfmenuitems = new Array<RFMenuItem>();
        this.secgroups = new Array<SecGroup>();
        this.subcriptions = new Array<Subscription>();
        this.validators = new Array<Validator>();
        this.viewgroups = new Array<ViewGroup>();
        this.lists = new Array<List>();
        this.dialogs = new Array<Dialog>();
        //// BIND DATA
        this.imagesFolder = new BindData();
        this.description = new BindData();

    }

}
