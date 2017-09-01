import React from 'react'

export class Home extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div>
                <h1>Get Excited! Routing works</h1>
                {this.props.children}
            </div>
        )
    }
}