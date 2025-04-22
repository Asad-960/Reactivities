import { makeAutoObservable} from 'mobx';



export default class CounterStore
{
    title = 'Counter store';
    count = 0;
    events: string[] = [

    ]
    constructor()
    {
        makeAutoObservable(this)
    }
    increment = (value = 1) => {
        this.count += value;
        this.events.push(`Incremented by ${value} - count is now ${this.count}`)
    }
    decrement = (value = 1) => {
        this.count -= value;
        this.events.push(`Decremented by ${value} - count is now ${this.count}`)
    }  
    
    get eventCount() {
        return this.events.length;
    }
}