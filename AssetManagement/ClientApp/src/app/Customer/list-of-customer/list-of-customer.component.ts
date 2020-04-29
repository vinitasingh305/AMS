import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-of-customer',
  templateUrl: './list-of-customer.component.html',
  styleUrls: ['./list-of-customer.component.css']
})
export class ListOfCustomerComponent implements OnInit {
  CustomerList: any = [];
  newObject = {}
  errorMsg: string;
  hideDeletePopup = true;
  recordsPerPage = 10;
  cities1: any;

  constructor() { }

  ngOnInit() {
    this.cities1 = [
      { label: 'Select', value: null },
      { label: 'New York', value: { id: 1, name: 'New York', code: 'NY' } },
      { label: 'Rome', value: { id: 2, name: 'Rome', code: 'RM' } },
      { label: 'London', value: { id: 3, name: 'London', code: 'LDN' } },
      { label: 'Istanbul', value: { id: 4, name: 'Istanbul', code: 'IST' } },
      { label: 'Paris', value: { id: 5, name: 'Paris', code: 'PRS' } }
    ];
  }
  cat0: any;

  showDeletePopup() {
    this.hideDeletePopup = false;
  }

  onCloseDeletePopup() {
    this.hideDeletePopup = true;
  }
  recordsoption = [
    { label: '10', value: 10 },
    { label: '50', value: 50 },
    { label: '100', value: 100 }
  ];

  questions = [
    {
      'question': 'Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required? Are arc flash labels required?',
      'id': 1
    },
    {
      'question': 'Are arc flash labels required?',
      'id': 2
    }
  ]
  cols = [
    { field: 'question', header: 'KnowledgeBase Question' },

  ];
}
