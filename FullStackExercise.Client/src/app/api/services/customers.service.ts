/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { FilterType } from '../models/filter-type';
import { GetCustomersByPageResponse } from '../models/get-customers-by-page-response';
import { UpdateCustomerCommand } from '../models/update-customer-command';

@Injectable({
  providedIn: 'root',
})
export class CustomersService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation getPagedCustomers
   */
  static readonly GetPagedCustomersPath = '/api/Customers';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getPagedCustomers$Plain()` instead.
   *
   * This method doesn't expect any response body
   */
  getPagedCustomers$Plain$Response(params?: {
    pageIndex?: number;
    pageSize?: number;
    keyWord?: string;
    sumComparison?: number;
    filters?: Array<FilterType>;
    higherLower?: boolean;

  }): Observable<StrictHttpResponse<GetCustomersByPageResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CustomersService.GetPagedCustomersPath, 'get');
    if (params) {

      rb.query('PageIndex', params.pageIndex);
      rb.query('PageSize', params.pageSize);
      rb.query('KeyWord', params.keyWord);
      rb.query('SumComparison', params.sumComparison);
      rb.query('Filters', params.filters);
      rb.query('HigherLower', params.higherLower);

    }
    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GetCustomersByPageResponse>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getPagedCustomers$Plain$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  getPagedCustomers$Plain(params?: {
    pageIndex?: number;
    pageSize?: number;
    keyWord?: string;
    sumComparison?: number;
    filters?: Array<FilterType>;
    higherLower?: boolean;

  }): Observable<GetCustomersByPageResponse> {

    return this.getPagedCustomers$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<GetCustomersByPageResponse>) => r.body as GetCustomersByPageResponse)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getPagedCustomers$Json()` instead.
   *
   * This method doesn't expect any response body
   */
  getPagedCustomers$Json$Response(params?: {
    pageIndex?: number;
    pageSize?: number;
    keyWord?: string;
    sumComparison?: number;
    filters?: Array<FilterType>;
    higherLower?: boolean;

  }): Observable<StrictHttpResponse<GetCustomersByPageResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CustomersService.GetPagedCustomersPath, 'get');
    if (params) {

      rb.query('PageIndex', params.pageIndex);
      rb.query('PageSize', params.pageSize);
      rb.query('KeyWord', params.keyWord);
      rb.query('SumComparison', params.sumComparison);
      rb.query('Filters', params.filters);
      rb.query('HigherLower', params.higherLower);

    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GetCustomersByPageResponse>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getPagedCustomers$Json$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  getPagedCustomers$Json(params?: {
    pageIndex?: number;
    pageSize?: number;
    keyWord?: string;
    sumComparison?: number;
    filters?: Array<FilterType>;
    higherLower?: boolean;

  }): Observable<GetCustomersByPageResponse> {

    return this.getPagedCustomers$Json$Response(params).pipe(
      map((r: StrictHttpResponse<GetCustomersByPageResponse>) => r.body as GetCustomersByPageResponse)
    );
  }

  /**
   * Path part for operation updateCustomer
   */
  static readonly UpdateCustomerPath = '/api/Customers';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateCustomer$Json()` instead.
   *
   * This method sends `application/json` and handles response body of type `application/json`
   */
  updateCustomer$Json$Response(params?: {

    body?: UpdateCustomerCommand
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, CustomersService.UpdateCustomerPath, 'patch');
    if (params) {


      rb.body(params.body, 'application/json');
    }
    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `updateCustomer$Json$Response()` instead.
   *
   * This method sends `application/json` and handles response body of type `application/json`
   */
  updateCustomer$Json(params?: {

    body?: UpdateCustomerCommand
  }): Observable<void> {

    return this.updateCustomer$Json$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
