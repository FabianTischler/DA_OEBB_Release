export class OEBBAntriebseinheit{
  constructor(
    public ae_id: number,
    public ae_bez: String,
    public ae_zustand: String,
    public ae_kmLeistung: number,
    public ae_pruefnr: number,
    public ae_nummer: String
  ){}
}
