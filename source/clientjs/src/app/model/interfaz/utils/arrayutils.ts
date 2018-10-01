export class ArrayUtils {
    public static removeElementInArray(theArray: any[], theElement: any) {
        if (theArray != undefined) {
            let index = theArray.indexOf(theElement);
            if (index > -1) {
                theArray.splice(index, 1);
            }
        }
    }

    public static cloneArray(theArray: any[]) {
        if (theArray != undefined) {
            return JSON.parse(JSON.stringify(theArray));

        }
        return undefined;
    }
    /** sort funcions by seuence field */
    public static sortBySequence(control1: any, control2: any): number {

        if (control1.sequence > control2.sequence) {
            return 1;
        } else {
            return -1;
        };
    }

    /** sort function by field */
    public static sortByField(control1: any, control2: any, fieldToSortBy: any): number {

        if (control1[fieldToSortBy] > control2[fieldToSortBy]) {
            return 1;
        } else {
            return -1;
        };
    }

}