export class Vehicle {
    constructor(
        public make: number,
        public model: number,
        public isRegistered: boolean,
        public features: number[],
        public contactName: string,
        public contactPhone: string,
        public contactEmail: string
    ){}
}