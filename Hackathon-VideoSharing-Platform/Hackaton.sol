// SPDX-License-Identifier: GPL-3.0

pragma solidity >=0.7.0 <0.8.0;

/**
 * @title Storage
 * @dev Store & retrieve value in a variable
 */
contract HackatonStorage {

    mapping (address => uint256) pubKeys;
    mapping (address => uint256) ipfsHashes;
    mapping (uint256 => uint256) prices;
    
     event Payment(
        address _from,
        address _to,
        uint amount
    );

    function pay(address payable _to) public payable {
        require(msg.value > 0);

        _to.transfer(msg.value);
        emit Payment(msg.sender, _to, msg.value);
    }
    
    function setPrice(uint256 ipfsHash, uint256 price) public {
        require (ipfsHashes[msg.sender] == ipfsHash);
        prices[ipfsHash] = price;
    }
    
    function setPubkey(uint256 pubKey) public {
        pubKeys[msg.sender] = pubKey;
    }
    
    function setIpfsHash(uint256 ipfsHash) public {
        ipfsHashes[msg.sender] = ipfsHash;
    }

    
    function getPrice(uint256 ipfsHash) public view returns (uint256){
        return prices[ipfsHash];
    } 
    
    function getPubKey(address addr) public view returns (uint256){
        return pubKeys[addr];
    }
    
    function getIpfsHash(address addr) public view returns (uint256){
        return ipfsHashes[addr];
    }
    
}