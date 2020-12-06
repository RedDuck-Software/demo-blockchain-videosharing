using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contracts.Contracts.HackatonStorage.ContractDefinition
{


    public partial class HackatonStorageDeployment : HackatonStorageDeploymentBase
    {
        public HackatonStorageDeployment() : base(BYTECODE) { }
        public HackatonStorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class HackatonStorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610363806100206000396000f3fe6080604052600436106100705760003560e01c8063d8da2fa81161004e578063d8da2fa8146100fd578063e757223014610142578063f7d975771461016c578063fce9512a1461019c57610070565b8063314fb8d0146100755780635f065346146100a1578063c9a5a951146100d3575b600080fd5b34801561008157600080fd5b5061009f6004803603602081101561009857600080fd5b50356101cf565b005b61009f600480360360608110156100b757600080fd5b506001600160a01b0381351690602081013590604001356101e1565b3480156100df57600080fd5b5061009f600480360360208110156100f657600080fd5b50356102a6565b34801561010957600080fd5b506101306004803603602081101561012057600080fd5b50356001600160a01b03166102b8565b60408051918252519081900360200190f35b34801561014e57600080fd5b506101306004803603602081101561016557600080fd5b50356102d3565b34801561017857600080fd5b5061009f6004803603604081101561018f57600080fd5b50803590602001356102e5565b3480156101a857600080fd5b50610130600480360360208110156101bf57600080fd5b50356001600160a01b0316610312565b33600090815260016020526040902055565b600082815260026020526040902054341080159061020d57503360009081526020819052604090205481145b61021657600080fd5b6040516001600160a01b038416903480156108fc02916000818181858888f1935050505015801561024b573d6000803e3d6000fd5b50604080513381526001600160a01b03851660208201523481830152606081018490526080810183905290517ffc8dd32b1cfbf2c565436049e9e556251a12304b0c3e624bc5e3b205692cf2dc9181900360a00190a1505050565b33600090815260208190526040902055565b6001600160a01b031660009081526001602052604090205490565b60009081526002602052604090205490565b33600090815260016020526040902054821461030057600080fd5b60009182526002602052604090912055565b6001600160a01b03166000908152602081905260409020549056fea2646970667358221220345a613fa070c213a0ba03f8501f549ba12781022419519692744c25bddf729b64736f6c63430007000033";
        public HackatonStorageDeploymentBase() : base(BYTECODE) { }
        public HackatonStorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetIpfsHashFunction : GetIpfsHashFunctionBase { }

    [Function("getIpfsHash", "uint256")]
    public class GetIpfsHashFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class GetPriceFunction : GetPriceFunctionBase { }

    [Function("getPrice", "uint256")]
    public class GetPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "ipfsHash", 1)]
        public virtual BigInteger IpfsHash { get; set; }
    }

    public partial class GetPubKeyFunction : GetPubKeyFunctionBase { }

    [Function("getPubKey", "uint256")]
    public class GetPubKeyFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class PayFunction : PayFunctionBase { }

    [Function("pay")]
    public class PayFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "ipfsHash", 2)]
        public virtual BigInteger IpfsHash { get; set; }
        [Parameter("uint256", "pubKey", 3)]
        public virtual BigInteger PubKey { get; set; }
    }

    public partial class SetIpfsHashFunction : SetIpfsHashFunctionBase { }

    [Function("setIpfsHash")]
    public class SetIpfsHashFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "ipfsHash", 1)]
        public virtual BigInteger IpfsHash { get; set; }
    }

    public partial class SetPriceFunction : SetPriceFunctionBase { }

    [Function("setPrice")]
    public class SetPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "ipfsHash", 1)]
        public virtual BigInteger IpfsHash { get; set; }
        [Parameter("uint256", "price", 2)]
        public virtual BigInteger Price { get; set; }
    }

    public partial class SetPubkeyFunction : SetPubkeyFunctionBase { }

    [Function("setPubkey")]
    public class SetPubkeyFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pubKey", 1)]
        public virtual BigInteger PubKey { get; set; }
    }

    public partial class PaymentEventDTO : PaymentEventDTOBase { }

    [Event("Payment")]
    public class PaymentEventDTOBase : IEventDTO
    {
        [Parameter("address", "_from", 1, false )]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2, false )]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint256", "ipfsHash", 4, false )]
        public virtual BigInteger IpfsHash { get; set; }
        [Parameter("uint256", "pubKey", 5, false )]
        public virtual BigInteger PubKey { get; set; }
    }

    public partial class GetIpfsHashOutputDTO : GetIpfsHashOutputDTOBase { }

    [FunctionOutput]
    public class GetIpfsHashOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetPriceOutputDTO : GetPriceOutputDTOBase { }

    [FunctionOutput]
    public class GetPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetPubKeyOutputDTO : GetPubKeyOutputDTOBase { }

    [FunctionOutput]
    public class GetPubKeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }








}
