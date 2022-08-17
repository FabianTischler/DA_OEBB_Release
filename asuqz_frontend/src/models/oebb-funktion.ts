import { OEBBMessergebnisse } from './oebb-messergebnisse';
export class OEBBFunktion{
  constructor(
    public id: number,
    public beschreibung: string,
    public headersize: number,
    public entries: number,
    public echtEntries: number,
    public numRead: number,
    public messergebnisse: OEBBMessergebnisse[]
  ){}
}
