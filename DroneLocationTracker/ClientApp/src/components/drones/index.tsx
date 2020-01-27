import React from "react";
import moment from "moment";

import './index.scss';

import {
	DroneService,
	lazyInject,
	Service,
	IDroneDto,
} from '../../services';
import { Table, Container, Card } from "react-bootstrap";

interface Props {
}

interface State {
	drones: IDroneDto[];

	isLoading: boolean;
}

class Drones extends React.Component<Props, State> {
	@lazyInject(Service.Drone) private _droneService!: DroneService;

	constructor(props: Props) {
		super(props);

		this.state = {
			drones: [],

			isLoading: true,
		};
	}

	public async componentDidMount() {
		const drones = await this._droneService.list();

		this.setState({ drones });
	}

	render() {
		return (
			<Container>
				<Card>
					<Card.Body>
						<Table hover>
							<thead>
								<tr>
									<th>Drone</th>
									<th>Current Speed</th>
									<th>Last Communicated</th>
								</tr>
							</thead>
							<tbody>
								{this.state.drones.map(x => {
									return (
										<tr>
											<td>
												<div>
													<h6><b>{x.name}</b></h6>
													<small>{x.droneId}</small>
												</div>
											</td>
											<td>0</td>
											<td>{x.lastLocation ? x.lastLocation.timestamp.format("YYYY-MM-DD HH:MM:SS ZZ") : ""}</td>
										</tr>
									);
								})}
							</tbody>
						</Table>
					</Card.Body>
				</Card>
			</Container>
		);
	}
}

export default Drones;
