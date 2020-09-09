import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import _ from 'lodash';
import {
    Container,
    FloatGrid as Grid,
} from './../../components';

import { setupPage } from './../../components/Layout/setupPage';
import HomeAnonymous from './HomeAnonymous';
import HomeAuthenticated from './HomeAuthenticated';


const LAYOUT = {
    'metric-v-target-users': { h: 6, md: 4 },
    'metric-v-target-sessions': { h: 6, md: 4 },
    'metric-v-target-pageviews': { h: 6, md: 4 },
    'analytics-audience-metrics': { h: 9, minH: 7 },
    'traffic-channels': { md: 6, h: 6 },
    'sessions': { md: 6, h: 6, maxH: 9, minW: 3 },
    'spend': { md: 6, h: 7 },
    'website-performance': { md: 6, h: 11 },
    'organic-traffic': { md: 6, h: 10 }
}

const SessionByDevice = (props) => (
    <div className={classes['session']}>
        <div className={classes['session__title']}>
            { props.title }
        </div>
        <div className={classes['session__values']}>
            <div className={`${classes['session__percentage']} text-${props.color}`}>
                { props.valuePercent }%
            </div>
            <div className={`${classes['session__value']} text-${props.color}`}>
                { props.value }
            </div>
        </div>
    </div>
);
SessionByDevice.propTypes = {
    title: PropTypes.node,
    color: PropTypes.string,
    valuePercent: PropTypes.string,
    value: PropTypes.string
}

// `process.env` is the one defined in the webpack's DefinePlugin
const envVariables = process.env;

// Read vars from envVariables object
const {
    APP_ENV,
    API_BASE_URL
} = envVariables;

class Home extends React.Component {
    //static propTypes = {
    //    pageConfig: PropTypes.object
    //};

    componentDidMount() {
        //const { pageConfig } = this.props;
        
        //pageConfig.setElementsVisibility({
        //    sidebarHidden: true
        //});
    }

    componentWillUnmount() {
        //const { pageConfig } = this.props;

        //pageConfig.setElementsVisibility({
        //    sidebarHidden: false
        //});
    }

    render() {

        //console.log(process.env);
        //console.log(process.env.NODE_ENV);
        console.log("Environment: ");
        console.log(APP_ENV);
        console.log(API_BASE_URL);

        return (
            <React.Fragment>
                <Container fluid={ false }>
 
                    {this.props.authentication.LoggedIn

                        ?<HomeAuthenticated/>
                        :<HomeAnonymous/>
                    }

                </Container>

            </React.Fragment>
        );
    }
}


const mapStateToProps = state => {
    return { authentication: state.authentication };
};

export default connect(
    mapStateToProps
)(Home);

// export default setupPage({
//     pageTitle: 'Home'
// })(Home);
