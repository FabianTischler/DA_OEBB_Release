export class OEBBKriterien{
  constructor(
    public name: string,
    public angesprochen: number,
    public minWert: number,
    public maxWert: number,
    public istWert: number,
    public resultCode: number,
    public maskMin: number,
    public maskMax: number,
    public messCount: number
  ){}
}
