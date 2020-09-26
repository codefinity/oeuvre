import React from 'react';
import { Link } from 'react-router-dom';

import { connect } from 'react-redux';
import { register } from '../Authentication.actions';

import {
    Form,
    FormGroup,
    FormText,
    Input,
    CustomInput,
    Button,
    Label,
    EmptyLayout,
    ThemeConsumer,
    Col,
    InputGroup
} from './../../../components';

import { HeaderAuth } from "../../components/Pages/HeaderAuth";
import { FooterAuth } from "../../components/Pages/FooterAuth";

class Register extends React.Component {

    state = {
        tenantId: '42D60457-5A80-4C83-96B6-890A5E5E4D22',
        emailId: '',
        firstName:'',
        lastName:'',
        countryCode:'',
        mobileNumber:'',
        password: '',
        acceptTerms: false,
        submitted: false
    };

    handleSubmit =(e) => {

        e.preventDefault();

        console.log("Register Form Submitted");

        this.setState({ submitted: true });

        this.props.register(this.state.tenantId,
                            this.state.emailId, 
                            this.state.firstName, 
                            this.state.lastName, 
                            this.state.countryCode, 
                            this.state.mobileNumber, 
                            this.state.password,
                            this.state.acceptTerms);

    }

    render() {

        console.log(this.state.acceptTerms);

        return (
            
            <EmptyLayout>
            <EmptyLayout.Section center width={ 480 }>
                { /* START Header */}
                <HeaderAuth 
                    title="Create Account"
                />
                { /* END Header */}
                { /* START Form */}
                <Form className="mb-3" onSubmit={this.handleSubmit}>
                <FormGroup>
                        <Label for="emailid">
                            Email Adress
                        </Label>
                        <Input type="email" name="email" id="emailid" 
                                placeholder="Enter Email..." className="bg-white" 
                                value={this.state.emailId}
                                onChange={(e)=>this.setState({emailId: e.target.value})} />
                        <FormText color="muted">
                            We&amp;ll never share your email with anyone else.
                        </FormText>
                    </FormGroup>
                    <FormGroup>
                        <Label for="firstname">
                            First Name
                        </Label>
                        <Input type="text" name="text" id="firstname" 
                                placeholder="Enter Firstname..." className="bg-white" 
                                value={this.state.firstName}
                                onChange={(e)=>this.setState({firstName: e.target.value})} />
                    </FormGroup>
                    <FormGroup>
                        <Label for="lastname">
                            Lastname
                        </Label>
                        <Input type="text" name="text" id="lastname" 
                                placeholder="Enter Lastname..." className="bg-white" 
                                value={this.state.lastName}
                                onChange={(e)=>this.setState({lastName: e.target.value})} />
                    </FormGroup>
    
                    <FormGroup>
                        <Label for="multipleInputs">
                            Mobile Number
                        </Label>
    
                            <InputGroup>
                                <Input placeholder="Country Code..." id="multipleInputs" className="bg-white"
                                        value={this.state.countryCode}
                                        onChange={(e)=>this.setState({countryCode: e.target.value})} />
                                <Input placeholder="Mobile No..." id="multipleInputs" className="bg-white w-50"
                                        value={this.state.mobileNumber}
                                        onChange={(e)=>this.setState({mobileNumber: e.target.value})} />
                            </InputGroup>
    
                    </FormGroup>
    
                    <FormGroup>
                        <Label for="password">
                            Password
                        </Label>
                        <Input type="password" name="password" id="password" 
                                placeholder="Password..." className="bg-white"
                                value={this.state.password}
                                onChange={(e)=>this.setState({password: e.target.value})} />
                    </FormGroup>
    
                    <FormGroup>
                        <CustomInput type="checkbox" id="acceptTerms" 
                                        label="Accept Terms and Privacy Policy" inline 
                                        value={this.state.acceptTerms}
                                        
                                        onChange={(e)=> {this.setState({acceptTerms: e.target.checked});}} />
                    </FormGroup>
                    <ThemeConsumer>
                    {
                        ({ color }) => (
                            <Button color={ color }>
                                Create Account
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
                    <Link to="/login" className="ml-auto text-decoration-none">
                        Login
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
    { register }
)(Register);
