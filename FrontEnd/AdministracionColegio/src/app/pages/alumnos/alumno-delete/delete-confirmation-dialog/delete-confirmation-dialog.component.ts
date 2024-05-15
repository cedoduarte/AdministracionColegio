import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-delete-confirmation-dialog',
  standalone: true,
  imports: [],
  templateUrl: './delete-confirmation-dialog.component.html',
  styleUrl: './delete-confirmation-dialog.component.css'
})
export class DeleteConfirmationDialogComponent {
  @Output() responseClicked = new EventEmitter<boolean>();

  handleYes() {
    this.responseClicked.emit(true);
  }
  
  handleNo() {
    this.responseClicked.emit(false);
  }
}
