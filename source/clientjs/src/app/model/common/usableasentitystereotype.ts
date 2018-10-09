import { InheritanceType } from "./Inheritancetype";

export class UsableAsEntityStereotype {

    inheritanceType: InheritanceType;
    sourceApplication: string

    
    constructor(){
        this.inheritanceType = InheritanceType.NoInheritance;
    }
}