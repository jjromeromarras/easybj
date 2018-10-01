import { BaseEntity } from '../../common/baseentity'
import { Entity } from '../views/entity/entity';

export class Relationship extends BaseEntity {
    souce: Entity;
    target: Entity;
}