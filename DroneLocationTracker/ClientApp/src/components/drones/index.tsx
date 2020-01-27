import React from "react";

import './index.scss';

import {
	DroneService,
	lazyInject,
	Service,
	IDroneDto,
} from '../../services';
import {
	Button,
	Card,
	Container,
	Spinner,
	Table,
} from "react-bootstrap";

const Drone = require('../../resources/drone.svg').default;

interface Props {
}

interface State {
	drones: IDroneDto[];

	isLoading: boolean;
	hasError: boolean;
}

class Drones extends React.Component<Props, State> {
	@lazyInject(Service.Drone) private _droneService!: DroneService;

	constructor(props: Props) {
		super(props);

		this.state = {
			drones: [],

			isLoading: false,
			hasError: false,
		};
	}

	public async componentDidMount() {
		this.setState({ isLoading: true });

		try {
			const drones = await this._droneService.list();

			this.setState({ drones, hasError: false });
		} catch {
			this.setState({ hasError: true });	
		} finally {
			this.setState({ isLoading: false });
		}
	}

	render() {
		if (this.state.isLoading) {
			return (
				<Spinner animation="border" variant="info" />
			);
		}

		if (this.state.hasError) {
			return (
				<div className="centred">
					<img src={Drone} alt="drone" className="small" />
					<h5>Error fetching drones.</h5>
					<Button variant="link" onClick={() => window.location.reload()}>Try again?</Button>
				</div>
			);
		}

		return (
			<Container>
				<h2 className="heading">Drones</h2>
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
