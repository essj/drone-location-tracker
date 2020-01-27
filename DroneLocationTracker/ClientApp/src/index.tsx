import * as React from 'react';
import * as ReactDOM from 'react-dom';
import Router from './router';

import 'bootstrap/dist/css/bootstrap.min.css';
import './index.scss';

ReactDOM.render(
	<Router />,
	document.getElementById('app') as HTMLElement,
);
