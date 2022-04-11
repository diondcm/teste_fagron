import axios from "axios";
import { AxiosInstance } from "axios";
import { ErrorHandler } from "@angular/core";
import { Injectable } from "@angular/core";
import { IClientes } from "./ServicesModel/Interface/ICliente";
// ----------------------------------------------------------------------------------- //
// ----------------------------------------------------------------------------------- //
 
export interface ErrorResponse {
	id: string;
	code: string;
	message: string;
}
 
@Injectable({
	providedIn: "root"
})
export class ServicesApi {
 
	private axiosClient: AxiosInstance;
	private errorHandler: ErrorHandler;
 
	// I initialize the ApiClient.
	constructor( errorHandler: ErrorHandler ) {
 
		this.errorHandler = errorHandler;
 
		// The ApiClient wraps calls to the underlying Axios client.
		this.axiosClient = axios.create({
			baseURL: 'https://localhost:44327/',
			//headers.common['Authorization'] = AUTH_TOKEN,
			headers: {
				// "X-Initialized-At": Date.now().toString(),
				// "Access-Control-Allow-Origin": "*",
				"Content-Type": "application/json; charset=utf-8",
			}
		});
 
	}
    // ---
	// PUBLIC METHODS.
	// ---
 
	// I perform a GET request with the given options.
	public async getAll<IClientes>() : Promise<IClientes> {
 
		try {
			//JSON.stringify({ answer: 42 });
			var axiosResponse = await this.axiosClient.request<IClientes>({
				method: "get",
				url: "v1/Clientes/GetAll",
				params: null,
			});
            //console.log(axiosResponse.data);
			return( axiosResponse.data );
 
		} catch ( error ) {
 
			return( Promise.reject( this.normalizeError( error ) ) );
 
		}
 
	}
 
	// ---
	// PRIVATE METHODS.
	// ---
 
	// Errors can occur for a variety of reasons. I normalize the error response so that
	// the calling context can assume a standard error structure.
	private normalizeError( error: any ) : ErrorResponse {
 
		this.errorHandler.handleError( error );
 
		// NOTE: Since I'm not really dealing with a production API, this doesn't really
		// normalize anything (ie, this is not the focus of this demo).
		return({
			id: "-1",
			code: "UnknownError",
			message: "An unexpected error occurred."
		});
 
	}
 
}