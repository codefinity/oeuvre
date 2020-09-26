import React from 'react';
import { Link } from 'react-router-dom';

import { connect } from 'react-redux';
import { authenticate } from '../Authentication.actions';

import {
    Form,
    FormGroup,
    FormText,
    Input,
    CustomInput,
    Button,
    Label,
    EmptyLayout,
    ThemeConsumer
} from './../../../components';

import { HeaderAuth } from "../../components/Pages/HeaderAuth";
import { FooterAuth } from "../../components/Pages/FooterAuth";

class Login extends React.Component {

    state = {
        emailId: '',
        password: '',
        submitted: false
    };

    handleSubmit =(e) => {

        e.preventDefault();

        console.log("Form Submitted");

        this.setState({ submitted: true });

        this.props.authenticate(this.state.emailId, this.state.password);


        //const { dispatch } = this.props;
        //if (username && password) {
            //dispatch(userActions.login(emailId, password));
        //}

    }

    render() {

        // console.log(this.state.password);

        return (

            <EmptyLayout>
                <EmptyLayout.Section center>
                    { /* START Header */}
                    <HeaderAuth
                        title="Sign In to Application"
                    />
                    { /* END Header */}
                    { /* START Form */}
                    <Form className="mb-3" onSubmit={this.handleSubmit}>
                        <FormGroup>
                            <Label for="emailAdress">
                                Email Adress
                            </Label>
                            <Input type="email" name="email" id="emailAdress" 
                                        placeholder="Enter email..." className="bg-white" 
                                        value={this.state.emailId}
                                        onChange={(e)=>this.setState({emailId: e.target.value})} 
                                        />
                        </FormGroup>
                        <FormGroup>
                            <Label for="password">
                                Password
                            </Label>
                            <Input type="password" name="password" id="password" 
                                    placeholder="Password..." className="bg-white"
                                    value={this.state.password}
                                    onChange={(e)=>this.setState({password: e.target.value})} 
                                    />
                        </FormGroup>
                        <FormGroup>
                            <CustomInput type="checkbox" id="rememberPassword" label="Remember Password" inline />
                        </FormGroup>
                        <ThemeConsumer>
                            {
                                ({ color }) => (
                                    <Button color={color}
                                        //block tag={Link} 
                                        //to="/dashboards/analytics"
                                        >
                                        Sign In
                                    </Button>
                                )
                            }
                        </ThemeConsumer>
                    </Form>
                    { /* END Form */}
                    { /* START Bottom Links */}
                    <div className="d-flex mb-5">
                        <Link to="/forgot-password" className="text-decoration-none">
                            Forgot Password
                        </Link>
                        <Link to="/register" className="ml-auto text-decoration-none">
                            Register
                        </Link>
                    </div>
                    { /* END Bottom Links */}
                    { /* START Footer */}
                    <FooterAuth />
                    { /* END Footer */}
                </EmptyLayout.Section>
            </EmptyLayout>
        );

};

}


const mapStateToProps = state => {
    return { authentication: state.authentication };
};

export default connect(
    mapStateToProps,
    { authenticate }
)(Login);
