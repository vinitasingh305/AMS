import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { AssetService } from '../../Services/asset.service';
import { Asset } from '../../DTO/asset';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-new-asset',
  templateUrl: './add-new-asset.component.html',
  styleUrls: ['./add-new-asset.component.css']
})
export class AddNewAssetComponent implements OnInit {
  addNewAsset: FormGroup;
  constructor(private fb: FormBuilder, private assetService: AssetService, private toastr: ToastrService) { }
  isValidFormSubmitted = null;
  addAsset: Asset;
  errors: any;
  hideSpinner = true;
  ngOnInit() {
    this.setValue();
  }
  setValue() {
    this.addNewAsset = this.fb.group({
      assetName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      typeOfItem: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      itemDesc: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      quantity: ['', [Validators.required, Validators.pattern(/^[\d\.]+$/)]],
      itemBrand: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      bUName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      createdBy: [''],
  });
  }

  get assetName() {
    return this.addNewAsset.get('assetName');
  }


  get typeOfItem() {
    return this.addNewAsset.get('typeOfItem');
  }

  get itemDesc() {
    return this.addNewAsset.get('itemDesc');
  }

  get quantity() {
    return this.addNewAsset.get('quantity');
  }

  get itemBrand() {
    return this.addNewAsset.get('itemBrand');
  }

  get bUName() {
    return this.addNewAsset.get('bUName');
  }

  get createdBy() {
    return this.addNewAsset.get('createdBy');
  }
  showError(errMsg, errTitle) {
    this.toastr.error(errMsg, errTitle);
  }
  //To show success alert
  showSuccess(successMsg, successTitle) {
    this.toastr.success(successMsg, successTitle);;
  }

  AddAssetData() {
    this.isValidFormSubmitted = false;
    if (this.addNewAsset.invalid) {
      return;
    }
    this.isValidFormSubmitted = true;
    this.addAsset = new Asset();

    this.addAsset.assetName = this.addNewAsset.value.assetName;

    this.addAsset.bUName = this.addNewAsset.value.bUName;
    this.addAsset.itemDesc = this.addNewAsset.value.itemDesc;
    this.addAsset.itemBrand = this.addNewAsset.value.itemBrand;
    this.addAsset.quantity = this.addNewAsset.value.quantity;
    this.addAsset.typeOfItem = this.addNewAsset.value.typeOfItem;
    this.addAsset.createdBy = this.addNewAsset.value.createdBy;

    this.assetService.addAssetDetail(this.addAsset).subscribe(data => {
      console.log(data);
    }, error => {
      this.hideSpinner = true;
      this.errors = error;
      console.log(this.errors);
      this.showError(this.errors, 'Error');
    },
      () => {
        this.hideSpinner = true;
        this.showSuccess('New Asset has been created successfully!!!', 'Success');
        console.log(this.showSuccess);
      });
    this.setValue();
  }
}
