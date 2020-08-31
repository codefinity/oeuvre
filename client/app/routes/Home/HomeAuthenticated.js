import React from 'react';
import _ from 'lodash';
import {
    Container,
    FloatGrid as Grid,
} from './../../components';



class HomeAuthenticated extends React.Component {

    componentDidMount() {

    }

    componentWillUnmount() {

    }

    render() {

        return (
            <React.Fragment>
                <Container fluid={ false }>
 
                    Authenticated User

                </Container>

            </React.Fragment>
        );
    }
}

export default HomeAuthenticated;
