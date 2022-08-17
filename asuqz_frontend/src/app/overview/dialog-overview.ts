import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

export interface DialogData {
  pruefer: string;
}

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog-overview.html',
})
export class DialogOverview  {
  panelOpenState = false;
  kriterium = '';
  kriterien: String[] = [];

  constructor(
    public dialogRef: MatDialogRef<DialogOverview>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  save(): void{
    this.kriterien = [];
    this.dialogRef.close();
  }
  pushKriterium(): void{
    this.kriterien.push(this.kriterium);
    this.kriterium = '';
  }
}
