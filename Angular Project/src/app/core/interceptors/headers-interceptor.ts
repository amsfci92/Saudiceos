import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';

@Injectable()
export class AuthHeadersInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const _apiKey = 'saudiceos-api';
    const modifiedReq = req.clone({
      headers: req.headers.set('apiKey', _apiKey)
    })
    return next.handle(modifiedReq)
  }
}
