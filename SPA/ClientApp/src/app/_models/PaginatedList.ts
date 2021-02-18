import { PaginationHeaders } from "./PaginationHeaders";

export class PaginatedList<T> {
  data: T[];
  headers: PaginationHeaders;
}
