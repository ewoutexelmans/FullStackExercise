/* tslint:disable */
import { CustomerLookupDto } from './customer-lookup-dto';
export interface GetCustomersByPageResponse  {
  customers?: null | Array<CustomerLookupDto>;
  pageCount?: number;
  pageIndex?: number;
}
