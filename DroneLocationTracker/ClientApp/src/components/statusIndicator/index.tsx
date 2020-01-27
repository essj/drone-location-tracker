import React from 'react';
import classnames from 'classnames';

import './index.scss';

export type StatusIndicatorStatus = 'online' | 'offline' | 'stale';

interface Props {
	status: StatusIndicatorStatus;
	pulse?: boolean;
}

class StatusIndicator extends React.PureComponent<Props> {
	render() {
		return (
			<div className={classnames(
				"status",
				`status__${this.props.status}`,
				this.props.pulse && "pulse",
			)}>
				<div></div>
			</div>
		);
	}
}

export default StatusIndicator;
