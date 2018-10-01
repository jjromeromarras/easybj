import { Validator } from "./validator";

export class NumericValidator extends Validator {

    maxvalue: number;
    minvalue: number;
    precision: number;
}