import { IModel } from './model.interface';
export interface IMake {
    id: number;
    name: string;
    models: IModel[];
}