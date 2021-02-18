import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PaginatedList } from "../_models/PaginatedList";

export function getPagination<T>(url: string, params: HttpParams, http: HttpClient): Observable<PaginatedList<T>> {
  const paginatedList = new PaginatedList<T>();

  return http.get<T[]>(url, { observe: 'response', params }).pipe(
    map(response => {
      paginatedList.data = response.body;
      if (response.headers.get('Pagination')) {
        paginatedList.headers = JSON.parse(response.headers.get('Pagination'));
      }
      return paginatedList;
    })
  )
}


export function getPaginationHeaders(pageNumber: number, pageSize: number): HttpParams {
  let params = new HttpParams();

  params = params.append('pageNumber', pageNumber.toString());
  params = params.append('pageSize', pageSize.toString());

  return params;
}
