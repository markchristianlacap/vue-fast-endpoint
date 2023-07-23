/* eslint-disable */
/* prettier-ignore */
// @ts-nocheck
import { GlobalComponentConstructor } from "quasar";
import { RemoteDataTableProps, RemoteDataTableSlots } from "./types/data-table";
export {};

declare module "vue" {
  export interface GlobalComponents {
    RemoteDataTable: GlobalComponentConstructor<
      RemoteDataTableProps<T>,
      RemoteDataTableSlots
    >;
  }
}
