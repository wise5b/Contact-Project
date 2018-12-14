import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { ContactService } from '../Service/contact.service';
import { IContact } from '../Model/contact';
import {Response} from '@angular/http';
import 'rxjs/Rx';

@Component({
    selector: 'contact-page', 
    templateUrl: './user.component.html'
})

export class ContactComponent implements OnInit {
    @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate') editTemplate: TemplateRef<any>;
    message: string;
    contact: IContact;
    selContact: IContact;
    contacts: IContact[];
    isNewRecord: boolean;
    statusMessage: string;

    constructor(private _contactService: ContactService) {
        this.message = '';
    }

    ngOnInit() {
        this.loadContacts();
    }
 
    private loadContacts() {
        this._contactService.getContacts()
            .subscribe((resp: Response) => {
                this.contacts = resp.json(); 
            });
    }
 
    addContact() {
        this.contacts.push(this.selContact);
        this.isNewRecord = true;
    }
 
    editEmployee(contact: IContact) {
        this.selContact = contact;
    }

    loadTemplate(contact: IContact) {
        if (this.selContact && this.selContact.Id == contact.Id) {
            return this.editTemplate;
        } else {
            return this.readOnlyTemplate;
        }
    }     

    saveContact() {
        if (this.isNewRecord) {
            //adding new contact
            this._contactService.addContact(this.selContact).subscribe((resp: Response) => {
                this.contact = resp.json(),
                    this.statusMessage = 'Record Added Successfully.',
                    this.loadContacts();
            });
            this.isNewRecord = false;
            this.selContact = null;
 
        } else {
            this._contactService.updateContact(this.selContact).subscribe((resp: Response) => {
                this.statusMessage = 'Record Updated Successfully.',
                    this.loadContacts();
            });
            this.selContact = null;
 
        }
    }

    deleteContact(Id: string) {
        this._contactService.deleteContact(Id).subscribe((resp: Response) => {
            this.statusMessage = 'Record Deleted Successfully.',
                this.loadContacts();
        });
 
    }
}

