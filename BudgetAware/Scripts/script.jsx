class Company extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div>
                <div className='row'>
                    Company: {this.props.name}
                </div>
            </div>
        )
    }
}

class PurchaseSummary extends React.Component {
    constructor(props) {
        super(props);
        this.deserialize = this.deserialize.bind(this);
        this.state = {
            purchases: []
        }
    }

    deserialize() {
        let text = document.getElementById('ContentPlaceHolder1_hiddenJsonPurchases')
        let value = JSON.parse(text.innerText);
        let purchaseArray = Array.from(value);
        purchaseArray.forEach(i => {
            this.state.purchases.push(i.Company)
        });
        console.log(this.state.purchases)
    }

    render() {
        this.deserialize();
        return (this.state.purchases.map(e => <div key={e}><Company name={e} /></div>))
    }


}

ReactDOM.render(<PurchaseSummary />, document.getElementById('app'))
