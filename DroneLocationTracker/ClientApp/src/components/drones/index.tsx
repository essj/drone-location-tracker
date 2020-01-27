import React from 'react';
import moment from 'moment';

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
} from 'react-bootstrap';

import StatusIndicator, { StatusIndicatorStatus } from '../statusIndicator';

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

	/**
	 * An easy to understand time difference from the event occurrence to now.
	 * e.g. "2 minutes ago"
	 */
	private renderHumanTime(time: moment.Moment): JSX.Element | null {
		const diff = moment().diff(time);

		if (Math.abs(diff) < 10000)
			return (<>Just now</>);

		// The time is too far in the past, don't display a human time.
		if (diff < 0)
			return (null);

		return (<>{time.fromNow()}</>);
	}

	private renderMovement(time: moment.Moment, speed: number): JSX.Element {
		let status: StatusIndicatorStatus = "online";
		if (speed < 5)
			status = "stale";
		if (speed === 0)
			status = "offline";

		return (
			<div className="last-communicated">
				<StatusIndicator
					status={status}
					pulse={status === "offline"}
				/>
				<div className="time">
					{time.format("YYYY-MM-DD HH:mm:ss")}
					<small>{this.renderHumanTime(time)}</small>
				</div>
			</div>
		);
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
									<th>Current Speed (m/s)</th>
									<th>Last Communicated</th>
								</tr>
							</thead>
							<tbody>
								{this.state.drones.map(x => {
									return (
										<tr key={x.droneId}>
											<td>
												<div>
													<h6><b>{x.name}</b></h6>
													<small>{x.droneId}</small>
												</div>
											</td>
											<td>{x.lastLocation && (Math.round(x.lastLocation.speed * 100) / 100).toFixed(2)}</td>
											<td>
												{x.lastLocation && this.renderMovement(x.lastLocation.timestamp, x.lastLocation.speed)}
											</td>
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
