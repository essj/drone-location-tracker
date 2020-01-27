import * as React from 'react';
import { observer } from 'mobx-react';
import { Redirect, Route, Switch } from 'react-router';

import './index.scss';

import Drones from '../components/drones';

@observer
class App extends React.PureComponent {
	public render() {
		return (
			<Switch key="content">
				<Route exact path="/" component={Drones} />
				<Route component={() => <Redirect to="/" />} />
			</Switch>
		);
	}
}

export default App;
