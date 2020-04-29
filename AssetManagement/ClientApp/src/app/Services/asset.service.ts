import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { throwError, Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Asset } from '../DTO/asset';

@Injectable({
  providedIn: 'root'
})
export class AssetService {
  baseUrl = 'http://localhost:65142/api/Asset';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  addAssetDetail(addAsset: Asset): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl}/addAsset`, addAsset, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      //return Observable.throw(error.message || "Server Error");
      console.error('Client Side Error:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError('There is a problem with the service. We are notified & working on it.Please try again later.');
  }
}
