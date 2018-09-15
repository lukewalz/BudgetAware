class PurchaseSummary extends React.Component {
    constructor(props) {
        super(props);
        this.deserialize = this.deserialize.bind(this);
        this.componentDidMount = this.componentDidMount.bind(this);
        this.state = {
            purchases: []
        }
    }
    componentDidMount() {
        let purchasesText = this.deserialize(document.getElementById('ContentPlaceHolder1_hiddenJsonPurchases'));
    }

    deserialize(text) {
        let value = JSON.parse(text.innerText);

        this.setState({
            purchases: value
        })
    }

    render() {
        return (
            <p>{this.state.purchases.Company}</p>
        )
    }
}

ReactDOM.render(<PurchaseSummary />, document.getElementById('app'))
