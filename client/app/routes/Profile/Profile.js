import React from 'react';
import _ from 'lodash';
import {
    Container,
    FloatGrid as Grid,
} from './../../components';

import { setupPage } from './../../components/Layout/setupPage';


class Profile extends React.Component {

    componentDidMount() {

    }

    componentWillUnmount() {

    }

    render() {

        return (
            <React.Fragment>
                <Container fluid={ false }>
 
                    Profile

                </Container>

            </React.Fragment>
        );
    }
}

export default setupPage({
    pageTitle: 'Profile'
})(Profile);
