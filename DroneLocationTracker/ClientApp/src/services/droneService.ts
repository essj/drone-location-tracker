import { injectable, inject } from 'inversify';
import * as C from './client';
import {
	Service,
} from '.';

@injectable()
class DroneService {
	@inject(Service.Client) private client: C.Client;

	public async list(): Promise<C.IDroneDto[]> {
		return this.client.apiDronesV1();
	}
}

export default DroneService;
