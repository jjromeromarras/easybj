/*
Copyright (c) 2015 Fabio Landoni (http://fabiolandoni.ch/)


Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/


export class Dictionary<T extends number | string, U>{

    private arrayKeys: T[] = [];
    private arrayValues: U[] = [];
    public static getParsedObject(dictionaryObject: any): Dictionary<string, any> {
        let dict: Dictionary<string, any> = new Dictionary<string, any>();
        if (dictionaryObject.arrayKeys == undefined || dictionaryObject.arrayValues == undefined) {
            return dict;
        }
        let index = 0;
        while (index < dictionaryObject.arrayKeys.length) {
            dict.add(dictionaryObject.arrayKeys[index], dictionaryObject.arrayValues[index]);
            index++;
        }
        return dict;
    }

    private isEitherUndefinedNullOrStringEmpty(object: any): boolean {
        return (typeof object) === 'undefined' || object === null || object.toString() === '';
    }

    private checkKeyAndPerformAction(action: { (key: T, value?: U): void | U | boolean }, key: T, value?: U): void | U | boolean {
        if (this.isEitherUndefinedNullOrStringEmpty(key)) {
            throw new Error('Key is either undefined, null or an empty string.');
        }

        return action(key, value);
    }

    public add(currentKey: T, currentValue: U): void {

        let addAction = (key: T, value: U): void => {
            if (this.containsKey(key)) {
                throw new Error('An element with the same key already exists in the dictionary.');
            }

            this.arrayKeys.push(key);
            this.arrayValues.push(value);
        };

        this.checkKeyAndPerformAction(addAction, currentKey, currentValue);
    }

    public addorUpdate(currentKey: T, currentValue: U): void {

        let addAction = (key: T, value: U): void => {
            if (this.containsKey(key)) {
                this.remove(key);
            }

            this.arrayKeys.push(key);
            this.arrayValues.push(value);
        };

        this.checkKeyAndPerformAction(addAction, currentKey, currentValue);
    }

    public remove(currentKey: T): boolean {

        let removeAction = (key: T): boolean => {
            if (!this.containsKey(key)) {
                return false;
            }

            let index = this.arrayKeys.indexOf(key);
            this.arrayKeys.splice(index, 1);
            this.arrayValues.splice(index, 1);

            return true;
        };

        return <boolean>(this.checkKeyAndPerformAction(removeAction, currentKey));
    }

    public getValue(currentKey: T): U {

        let getValueAction = (key: T): U => {
            if (!this.containsKey(key)) {
                return null;
            }

            let index = this.arrayKeys.indexOf(key);
            return this.arrayValues[index];
        };

        return <U>this.checkKeyAndPerformAction(getValueAction, currentKey);
    }

    public containsKey(currentKey: T): boolean {

        let containsKeyAction = (key: T): boolean => {
            if (this.arrayKeys.indexOf(key) === -1) {
                return false;
            }
            return true;
        };

        return <boolean>this.checkKeyAndPerformAction(containsKeyAction, currentKey);
    }

    public changeValueForKey(currentKey: T, currentNewValue: U): void {

        let changeValueForKeyAction = (key: T, newValue: U): void => {
            if (!this.containsKey(key)) {
                throw new Error('In the dictionary there is no element with the given key.');
            }

            let index = this.arrayKeys.indexOf(key);
            this.arrayValues[index] = newValue;
        };

        this.checkKeyAndPerformAction(changeValueForKeyAction, currentKey, currentNewValue);
    }

    public keys(): T[] {
        return this.arrayKeys;
    }

    public values(): U[] {
        return this.arrayValues;
    }

    public count(): number {
        return this.arrayValues.length;
    }

    public parseObject(dictionaryObject: any): Dictionary<T, U> {
        let dict: Dictionary<T, U> = new Dictionary<T, U>();
        if (dictionaryObject.arrayKeys == undefined || dictionaryObject.arrayValues == undefined) {
            return dict;
        }
        let index = 0;
        while (index < dictionaryObject.arrayKeys.length) {
            dict.add(dictionaryObject.arrayKeys[index], dictionaryObject.arrayValues[index]);
            index++;
        }
        return dict;
    }


}
