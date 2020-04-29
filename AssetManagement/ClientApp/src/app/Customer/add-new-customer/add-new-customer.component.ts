import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { CustomerService } from '../../Services/customer.service';
import { phoneNumberValidator } from '../../Services/phone-validator.ts';
import { Customer } from '../../DTO/customer';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-new-customer',
  templateUrl: './add-new-customer.component.html',
  styleUrls: ['./add-new-customer.component.css']
})
export class AddNewCustomerComponent implements OnInit {
  addNewCustomer: FormGroup;
  constructor(private fb: FormBuilder, private customerService: CustomerService, private toastr: ToastrService) { }
  isValidFormSubmitted = null;
  addCustomer: Customer;
  errors: any;
  hideSpinner = true;
  ngOnInit() {
    this.setValue();
  }

  setValue() {
    this.addNewCustomer = this.fb.group({
      customername: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      contactnumber: ['', [Validators.required, phoneNumberValidator]],
      email: ['', [Validators.required, Validators.email]],
      createdBy: ['']
    });
  }
  get customername() {
    return this.addNewCustomer.get('customername');
  }

  get contactnumber() {
    return this.addNewCustomer.get('contactnumber');
  }

  get email() {
    return this.addNewCustomer.get('email');
  }

  get createdBy() {
    return this.addNewCustomer.get('createdBy');
  }
  showError(errMsg, errTitle) {
    this.toastr.error(errMsg, errTitle);
  }
  //To show success alert
  showSuccess(successMsg, successTitle) {
    this.toastr.success(successMsg, successTitle);;
  }

  AddCustomerData() {
    this.isValidFormSubmitted = false;
    if (this.addNewCustomer.invalid) {
      return;
    }
    this.isValidFormSubmitted = true;
    this.addCustomer = new Customer();

    this.addCustomer.customername = this.addNewCustomer.value.customername;

    this.addCustomer.email = this.addNewCustomer.value.email;
    this.addCustomer.contactnumber = this.addNewCustomer.value.contactnumber;
    this.addCustomer.createdBy = this.addNewCustomer.value.createdBy;

    this.customerService.addCustomerDetail(this.addCustomer).subscribe(data => {
      console.log(data);
    }, error => {
      this.hideSpinner = true;
      this.errors = error;
      console.log(this.errors);
      this.showError(this.errors, 'Error');
    },
      () => {
        this.hideSpinner = true;
        this.showSuccess('New Customer has been created successfully!!!', 'Success');
        console.log(this.showSuccess);
      });
    this.setValue();
  }


}
