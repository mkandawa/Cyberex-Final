/*
Navicat MySQL Data Transfer

Source Server         : Chats
Source Server Version : 50612
Source Host           : localhost:3306
Source Database       : dbchatrecord

Target Server Type    : MYSQL
Target Server Version : 50612
File Encoding         : 65001

Date: 2015-03-14 13:19:10
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `channel`
-- ----------------------------
DROP TABLE IF EXISTS `channel`;
CREATE TABLE `channel` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `link` varchar(255) NOT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `language` varchar(255) DEFAULT NULL,
  `lastBuildDate` varchar(255) DEFAULT NULL,
  `copyright` varchar(255) DEFAULT NULL,
  `docs` varchar(255) DEFAULT NULL,
  `ttl` varchar(255) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `ShareCodeID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `lastBuildDate` (`lastBuildDate`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of channel
-- ----------------------------

-- ----------------------------
-- Table structure for `channel2`
-- ----------------------------
DROP TABLE IF EXISTS `channel2`;
CREATE TABLE `channel2` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `ShareCodeID` int(11) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `lastBuildDate` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of channel2
-- ----------------------------

-- ----------------------------
-- Table structure for `chats`
-- ----------------------------
DROP TABLE IF EXISTS `chats`;
CREATE TABLE `chats` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ChannelID` int(11) NOT NULL,
  `title` varchar(255) DEFAULT NULL,
  `author` varchar(255) DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `link` varchar(255) DEFAULT NULL,
  `pubDate` varchar(255) DEFAULT NULL,
  `PubDateFull` char(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `chats_idx` (`author`,`PubDateFull`),
  KEY `FK-ChannelID` (`ChannelID`),
  CONSTRAINT `FK-ChannelID` FOREIGN KEY (`ChannelID`) REFERENCES `channel` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=517 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of chats
-- ----------------------------

-- ----------------------------
-- Table structure for `chats2`
-- ----------------------------
DROP TABLE IF EXISTS `chats2`;
CREATE TABLE `chats2` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) NOT NULL,
  `Description` varchar(1000) NOT NULL,
  `PubDate` date NOT NULL,
  `ChannelID` int(11) NOT NULL,
  `Creator` varchar(100) NOT NULL,
  `PubDateFull` char(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `chts2_idx` (`Creator`,`PubDateFull`)
) ENGINE=InnoDB AUTO_INCREMENT=931 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of chats2
-- ----------------------------

-- ----------------------------
-- Table structure for `sharecode`
-- ----------------------------
DROP TABLE IF EXISTS `sharecode`;
CREATE TABLE `sharecode` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ShareCodeText` varchar(4) NOT NULL,
  `Company` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ShareCodeText` (`ShareCodeText`)
) ENGINE=InnoDB AUTO_INCREMENT=3572 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of sharecode
-- ----------------------------
INSERT INTO `sharecode` VALUES ('2930', 'III ', '3i Group    ');
INSERT INTO `sharecode` VALUES ('2931', '3IN', '3i Infrastructure    ');
INSERT INTO `sharecode` VALUES ('2932', 'FOUR', '4Imprint Group    ');
INSERT INTO `sharecode` VALUES ('2933', '888 ', '888 Holdings    ');
INSERT INTO `sharecode` VALUES ('2934', 'MKLW', 'A&J Mucklow Group   ');
INSERT INTO `sharecode` VALUES ('2935', 'AAIF', 'Aberdeen Asian Income Fund Ltd. ');
INSERT INTO `sharecode` VALUES ('2936', 'AAS ', 'Aberdeen Asian Smaller Companies..  ');
INSERT INTO `sharecode` VALUES ('2937', 'ADN ', 'Aberdeen Asset Management   ');
INSERT INTO `sharecode` VALUES ('2938', 'ABD ', 'Aberdeen New Dawn Investment Trust ');
INSERT INTO `sharecode` VALUES ('2939', 'ANW ', 'Aberdeen New Thai Inv Trust ');
INSERT INTO `sharecode` VALUES ('2940', 'AUKT', 'Aberdeen UK Tracker Trust  ');
INSERT INTO `sharecode` VALUES ('2941', 'AGIT', 'Aberforth Geared Income Trust  ');
INSERT INTO `sharecode` VALUES ('2942', 'ASL ', 'Aberforth Smaller Companies Trust  ');
INSERT INTO `sharecode` VALUES ('2943', 'ACD ', 'Acencia Debt Strategies Ltd.  ');
INSERT INTO `sharecode` VALUES ('2944', 'ADM ', 'Admiral Group    ');
INSERT INTO `sharecode` VALUES ('2945', 'ADMF', 'Advance Developing Markets Fund .. ');
INSERT INTO `sharecode` VALUES ('2946', 'AFR ', 'Afren     ');
INSERT INTO `sharecode` VALUES ('2947', 'ABG ', 'African Barrick Gold   ');
INSERT INTO `sharecode` VALUES ('2948', 'AGA ', 'Aga Rangemaster Group   ');
INSERT INTO `sharecode` VALUES ('2949', 'AGK ', 'Aggreko     ');
INSERT INTO `sharecode` VALUES ('2950', 'ANH ', 'AL Noor Hospitals Group  ');
INSERT INTO `sharecode` VALUES ('2951', 'AEFS', 'Alcentra Euorpean Floating Rate .. ');
INSERT INTO `sharecode` VALUES ('2952', 'ALNT', 'Alent     ');
INSERT INTO `sharecode` VALUES ('2953', 'ATST', 'Alliance Trust    ');
INSERT INTO `sharecode` VALUES ('2954', 'ATT ', 'Allianz Technology Trust   ');
INSERT INTO `sharecode` VALUES ('2955', 'AMEC', 'Amec     ');
INSERT INTO `sharecode` VALUES ('2956', 'AML ', 'Amlin     ');
INSERT INTO `sharecode` VALUES ('2957', 'AAL ', 'Anglo American    ');
INSERT INTO `sharecode` VALUES ('2958', 'APF ', 'Anglo Pacific Group   ');
INSERT INTO `sharecode` VALUES ('2959', 'AEP ', 'Anglo-Eastern Plantations    ');
INSERT INTO `sharecode` VALUES ('2960', 'AIE ', 'Anite     ');
INSERT INTO `sharecode` VALUES ('2961', 'ANTO', 'Antofagasta     ');
INSERT INTO `sharecode` VALUES ('2962', 'AO  ', 'AO World    ');
INSERT INTO `sharecode` VALUES ('2963', 'AQP ', 'Aquarius Platinum Ld   ');
INSERT INTO `sharecode` VALUES ('2964', 'ARM ', 'ARM Holdings    ');
INSERT INTO `sharecode` VALUES ('2965', 'ARW ', 'Arrow Global Group   ');
INSERT INTO `sharecode` VALUES ('2966', 'ATS ', 'Artemis Alpha Trust   ');
INSERT INTO `sharecode` VALUES ('2967', 'ALY ', 'Ashley (Laura) Holding   ');
INSERT INTO `sharecode` VALUES ('2968', 'ASHM', 'Ashmore Group    ');
INSERT INTO `sharecode` VALUES ('2969', 'AHT ', 'Ashtead Group    ');
INSERT INTO `sharecode` VALUES ('2970', 'ARMS', 'Asia Resource Minerals   ');
INSERT INTO `sharecode` VALUES ('2971', 'ATR ', 'Asian Total Return Investment Co.. ');
INSERT INTO `sharecode` VALUES ('2972', 'ABF ', 'Associated British Foods   ');
INSERT INTO `sharecode` VALUES ('2973', 'AGR ', 'Assura Group Ltd.   ');
INSERT INTO `sharecode` VALUES ('2974', 'AZN ', 'AstraZeneca     ');
INSERT INTO `sharecode` VALUES ('2975', 'ATK ', 'Atkins (WS)    ');
INSERT INTO `sharecode` VALUES ('2976', 'AVV ', 'Aveva Group    ');
INSERT INTO `sharecode` VALUES ('2977', 'AV  ', 'Aviva     ');
INSERT INTO `sharecode` VALUES ('2978', 'AVON', 'Avon Rubber    ');
INSERT INTO `sharecode` VALUES ('2979', 'BAB ', 'Babcock International Group   ');
INSERT INTO `sharecode` VALUES ('2980', 'BACT', 'Bacit Limited    ');
INSERT INTO `sharecode` VALUES ('2981', 'BA  ', 'BAE Systems    ');
INSERT INTO `sharecode` VALUES ('2982', 'BGFD', 'Baillie Gifford Japan Trust  ');
INSERT INTO `sharecode` VALUES ('2983', 'BGS ', 'Baillie Gifford Shin Nippon  ');
INSERT INTO `sharecode` VALUES ('2984', 'BBY ', 'Balfour Beatty    ');
INSERT INTO `sharecode` VALUES ('2985', 'BGEO', 'Bank of Georgia Holdings  ');
INSERT INTO `sharecode` VALUES ('2986', 'BNKR', 'Bankers Inv Trust   ');
INSERT INTO `sharecode` VALUES ('2987', 'BARC', 'Barclays     ');
INSERT INTO `sharecode` VALUES ('2988', 'BEE ', 'Baring Emerging Europe   ');
INSERT INTO `sharecode` VALUES ('2989', 'BAG ', 'Barr (A.G.)    ');
INSERT INTO `sharecode` VALUES ('2990', 'BDEV', 'Barratt Developments    ');
INSERT INTO `sharecode` VALUES ('2991', 'BVC ', 'BATM Advanced Communications Ltd.  ');
INSERT INTO `sharecode` VALUES ('2992', 'BBA ', 'BBA Aviation    ');
INSERT INTO `sharecode` VALUES ('2993', 'BBGI', 'BBGI SICAV S.A. (DI)  ');
INSERT INTO `sharecode` VALUES ('2994', 'BEZ ', 'Beazley     ');
INSERT INTO `sharecode` VALUES ('2995', 'BWY ', 'Bellway     ');
INSERT INTO `sharecode` VALUES ('2996', 'BRSN', 'Berendsen     ');
INSERT INTO `sharecode` VALUES ('2997', 'BKG ', 'Berkeley Group Holdings (The)  ');
INSERT INTO `sharecode` VALUES ('2998', 'BET ', 'Betfair Group    ');
INSERT INTO `sharecode` VALUES ('2999', 'BG  ', 'BG Group    ');
INSERT INTO `sharecode` VALUES ('3000', 'BHCG', 'BH Credit Catalysts Ltd Ord Red');
INSERT INTO `sharecode` VALUES ('3001', 'BHGG', 'BH Global Ltd. GBP Shares ');
INSERT INTO `sharecode` VALUES ('3002', 'BHMG', 'BH Macro Ltd. GBP Shares ');
INSERT INTO `sharecode` VALUES ('3003', 'BLT ', 'BHP Billiton    ');
INSERT INTO `sharecode` VALUES ('3004', 'BYG ', 'Big Yellow Group   ');
INSERT INTO `sharecode` VALUES ('3005', 'BIOG', 'Biotech Growth Trust (The)  ');
INSERT INTO `sharecode` VALUES ('3006', 'BRCI', 'BlackRock Commodities Income Inv..  ');
INSERT INTO `sharecode` VALUES ('3007', 'BEEP', 'BlackRock Emerging Europe   ');
INSERT INTO `sharecode` VALUES ('3008', 'BRFI', 'Blackrock Frontiers Investment T..  ');
INSERT INTO `sharecode` VALUES ('3009', 'BRGE', 'BlackRock Greater Europe Inv Trust ');
INSERT INTO `sharecode` VALUES ('3010', 'BRLA', 'BlackRock Latin American Inv Trust ');
INSERT INTO `sharecode` VALUES ('3011', 'BRNA', 'Blackrock North American Income .. ');
INSERT INTO `sharecode` VALUES ('3012', 'BRSC', 'BlackRock Smaller Companies Trust  ');
INSERT INTO `sharecode` VALUES ('3013', 'THRG', 'Blackrock Throgmorton Trust   ');
INSERT INTO `sharecode` VALUES ('3014', 'BRWM', 'BlackRock World Mining Trust  ');
INSERT INTO `sharecode` VALUES ('3015', 'BMY ', 'Bloomsbury Publishing    ');
INSERT INTO `sharecode` VALUES ('3016', 'BABS', 'BlueCrest AllBlue Fund Ltd. GBP ..');
INSERT INTO `sharecode` VALUES ('3017', 'BBTS', 'Bluecrest Bluetrend Ltd Red GBP ');
INSERT INTO `sharecode` VALUES ('3018', 'BSIF', 'Bluefield Solar Income Fund Limi.. ');
INSERT INTO `sharecode` VALUES ('3019', 'BOY ', 'Bodycote     ');
INSERT INTO `sharecode` VALUES ('3020', 'BOK ', 'Booker Group    ');
INSERT INTO `sharecode` VALUES ('3021', 'BVS ', 'Bovis Homes Group   ');
INSERT INTO `sharecode` VALUES ('3022', 'BP  ', 'BP     ');
INSERT INTO `sharecode` VALUES ('3023', 'BMS ', 'Braemar Shipping Services   ');
INSERT INTO `sharecode` VALUES ('3024', 'BRAM', 'Brammer     ');
INSERT INTO `sharecode` VALUES ('3025', 'BRW ', 'Brewin Dolphin Holdings   ');
INSERT INTO `sharecode` VALUES ('3026', 'BRIT', 'Brit     ');
INSERT INTO `sharecode` VALUES ('3027', 'BATS', 'British American Tobacco   ');
INSERT INTO `sharecode` VALUES ('3028', 'BSET', 'British Assets Trust   ');
INSERT INTO `sharecode` VALUES ('3029', 'BTEM', 'British Empire Securities & Gene.. ');
INSERT INTO `sharecode` VALUES ('3030', 'BLND', 'British Land Co   ');
INSERT INTO `sharecode` VALUES ('3031', 'BPI ', 'British Polythene Industries   ');
INSERT INTO `sharecode` VALUES ('3032', 'BSY ', 'British Sky Broadcasting Group  ');
INSERT INTO `sharecode` VALUES ('3033', 'BVIC', 'Britvic     ');
INSERT INTO `sharecode` VALUES ('3034', 'BWNG', 'Brown (N.) Group   ');
INSERT INTO `sharecode` VALUES ('3035', 'BUT ', 'Brunner Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3036', 'BT.A', 'BT Group    ');
INSERT INTO `sharecode` VALUES ('3037', 'BTG ', 'BTG     ');
INSERT INTO `sharecode` VALUES ('3038', 'BNZL', 'Bunzl     ');
INSERT INTO `sharecode` VALUES ('3039', 'BRBY', 'Burberry Group    ');
INSERT INTO `sharecode` VALUES ('3040', 'BPTY', 'Bwin.party Digital Entertainment   ');
INSERT INTO `sharecode` VALUES ('3041', 'CWC ', 'Cable & Wireless Communications  ');
INSERT INTO `sharecode` VALUES ('3042', 'CNE ', 'Cairn Energy    ');
INSERT INTO `sharecode` VALUES ('3043', 'CLDN', 'Caledonia Investments    ');
INSERT INTO `sharecode` VALUES ('3044', 'CMBN', 'Cambian Group    ');
INSERT INTO `sharecode` VALUES ('3045', 'CDI ', 'Candover Investments    ');
INSERT INTO `sharecode` VALUES ('3046', 'CIU ', 'Cape     ');
INSERT INTO `sharecode` VALUES ('3047', 'CPI ', 'Capita     ');
INSERT INTO `sharecode` VALUES ('3048', 'CAPC', 'Capital & Counties Properties  ');
INSERT INTO `sharecode` VALUES ('3049', 'CAL ', 'Capital & Regional   ');
INSERT INTO `sharecode` VALUES ('3050', 'CGT ', 'Capital Gearing Trust   ');
INSERT INTO `sharecode` VALUES ('3051', 'CAR ', 'Carclo     ');
INSERT INTO `sharecode` VALUES ('3052', 'CARD', 'Card Factory    ');
INSERT INTO `sharecode` VALUES ('3053', 'CLLN', 'Carillion     ');
INSERT INTO `sharecode` VALUES ('3054', 'CCL ', 'Carnival     ');
INSERT INTO `sharecode` VALUES ('3055', 'CPR ', 'Carpetright     ');
INSERT INTO `sharecode` VALUES ('3056', 'CRM ', 'Carr\'s Milling Industries   ');
INSERT INTO `sharecode` VALUES ('3057', 'CGL ', 'Catlin Group Ltd.   ');
INSERT INTO `sharecode` VALUES ('3058', 'CEY ', 'Centamin (DI)    ');
INSERT INTO `sharecode` VALUES ('3059', 'CAU ', 'Centaur Media    ');
INSERT INTO `sharecode` VALUES ('3060', 'CNA ', 'Centrica     ');
INSERT INTO `sharecode` VALUES ('3061', 'CTR ', 'Charles Taylor    ');
INSERT INTO `sharecode` VALUES ('3062', 'CHG ', 'Chemring Group    ');
INSERT INTO `sharecode` VALUES ('3063', 'CSN ', 'Chesnara     ');
INSERT INTO `sharecode` VALUES ('3064', 'CHW ', 'Chime Communications    ');
INSERT INTO `sharecode` VALUES ('3065', 'CINE', 'Cineworld Group    ');
INSERT INTO `sharecode` VALUES ('3066', 'CIR ', 'Circassia Pharmaceuticals    ');
INSERT INTO `sharecode` VALUES ('3067', 'CMHY', 'City Merchants High Yield Trust ');
INSERT INTO `sharecode` VALUES ('3068', 'CYN ', 'City Natural Resources High Yiel.. ');
INSERT INTO `sharecode` VALUES ('3069', 'CTY ', 'City of London Inv Trust ');
INSERT INTO `sharecode` VALUES ('3070', 'CLIG', 'City of London Investment Group ');
INSERT INTO `sharecode` VALUES ('3071', 'CKN ', 'Clarkson     ');
INSERT INTO `sharecode` VALUES ('3072', 'CBG ', 'Close Brothers Group   ');
INSERT INTO `sharecode` VALUES ('3073', 'CLI ', 'CLS Holdings    ');
INSERT INTO `sharecode` VALUES ('3074', 'COB ', 'Cobham     ');
INSERT INTO `sharecode` VALUES ('3075', 'CCH ', 'Coca-Cola HBC AG (CDI)  ');
INSERT INTO `sharecode` VALUES ('3076', 'COLT', 'COLT Group SA   ');
INSERT INTO `sharecode` VALUES ('3077', 'CMS ', 'Communisis     ');
INSERT INTO `sharecode` VALUES ('3078', 'CPG ', 'Compass Group    ');
INSERT INTO `sharecode` VALUES ('3079', 'CCC ', 'Computacenter     ');
INSERT INTO `sharecode` VALUES ('3080', 'CNCT', 'Connect Group    ');
INSERT INTO `sharecode` VALUES ('3081', 'CSRT', 'Consort Medical    ');
INSERT INTO `sharecode` VALUES ('3082', 'COST', 'Costain Group    ');
INSERT INTO `sharecode` VALUES ('3083', 'CWD ', 'Countrywide     ');
INSERT INTO `sharecode` VALUES ('3084', 'CWK ', 'Cranswick     ');
INSERT INTO `sharecode` VALUES ('3085', 'CRST', 'Crest Nicholson Holdings   ');
INSERT INTO `sharecode` VALUES ('3086', 'CRH ', 'CRH     ');
INSERT INTO `sharecode` VALUES ('3087', 'CRDA', 'Croda International    ');
INSERT INTO `sharecode` VALUES ('3088', 'CSR ', 'CSR     ');
INSERT INTO `sharecode` VALUES ('3089', 'CCPG', 'CVC Credit Partners European Opp.. ');
INSERT INTO `sharecode` VALUES ('3090', 'DJAN', 'Daejan Holdings    ');
INSERT INTO `sharecode` VALUES ('3091', 'DCG ', 'Dairy Crest Group   ');
INSERT INTO `sharecode` VALUES ('3092', 'DRTY', 'Darty     ');
INSERT INTO `sharecode` VALUES ('3093', 'DCC ', 'DCC     ');
INSERT INTO `sharecode` VALUES ('3094', 'DLAR', 'De La Rue   ');
INSERT INTO `sharecode` VALUES ('3095', 'DEB ', 'Debenhams     ');
INSERT INTO `sharecode` VALUES ('3096', 'DPH ', 'Dechra Pharmaceuticals    ');
INSERT INTO `sharecode` VALUES ('3097', 'DLN ', 'Derwent London    ');
INSERT INTO `sharecode` VALUES ('3098', 'DSC ', 'Development Securities    ');
INSERT INTO `sharecode` VALUES ('3099', 'DVO ', 'Devro     ');
INSERT INTO `sharecode` VALUES ('3100', 'DAB ', 'Dexion Absolute Ltd. GBP Shares ');
INSERT INTO `sharecode` VALUES ('3101', 'DGE ', 'Diageo     ');
INSERT INTO `sharecode` VALUES ('3102', 'DIA ', 'Dialight     ');
INSERT INTO `sharecode` VALUES ('3103', 'DTY ', 'Dignity     ');
INSERT INTO `sharecode` VALUES ('3104', 'DPLM', 'Diploma     ');
INSERT INTO `sharecode` VALUES ('3105', 'DLG ', 'Direct Line Insurance Group  ');
INSERT INTO `sharecode` VALUES ('3106', 'DIVI', 'Diverse Income Trust (The)  ');
INSERT INTO `sharecode` VALUES ('3107', 'DC  ', 'Dixons Carphone    ');
INSERT INTO `sharecode` VALUES ('3108', 'DNO ', 'Domino Printing Sciences   ');
INSERT INTO `sharecode` VALUES ('3109', 'DOM ', 'Domino\'s Pizza Group   ');
INSERT INTO `sharecode` VALUES ('3110', 'DRX ', 'Drax Group    ');
INSERT INTO `sharecode` VALUES ('3111', 'DNE ', 'Dunedin Enterprise Investment Tr..  ');
INSERT INTO `sharecode` VALUES ('3112', 'DIG ', 'Dunedin Income Growth Inv Trust ');
INSERT INTO `sharecode` VALUES ('3113', 'DNDL', 'Dunedin Smaller Companies Inv Tr.. ');
INSERT INTO `sharecode` VALUES ('3114', 'DNLM', 'Dunelm Group    ');
INSERT INTO `sharecode` VALUES ('3115', 'E2V ', 'E2V Technologies    ');
INSERT INTO `sharecode` VALUES ('3116', 'EZJ ', 'easyJet     ');
INSERT INTO `sharecode` VALUES ('3117', 'ECWO', 'Ecofin Water & Power Opportunities ');
INSERT INTO `sharecode` VALUES ('3118', 'EFM ', 'Edinburgh Dragon Trust   ');
INSERT INTO `sharecode` VALUES ('3119', 'EDIN', 'Edinburgh Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3120', 'EWI ', 'Edinburgh Worldwide Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3121', 'ELTA', 'Electra Private Equity   ');
INSERT INTO `sharecode` VALUES ('3122', 'ECM ', 'Electrocomponents     ');
INSERT INTO `sharecode` VALUES ('3123', 'ELM ', 'Elementis     ');
INSERT INTO `sharecode` VALUES ('3124', 'ENQ ', 'EnQuest     ');
INSERT INTO `sharecode` VALUES ('3125', 'ETI ', 'Enterprise Inns    ');
INSERT INTO `sharecode` VALUES ('3126', 'ETO ', 'Entertainment One Limited   ');
INSERT INTO `sharecode` VALUES ('3127', 'EPG ', 'EP Global Opportunities Trust  ');
INSERT INTO `sharecode` VALUES ('3128', 'ESNT', 'Essentra     ');
INSERT INTO `sharecode` VALUES ('3129', 'ESUR', 'esure Group    ');
INSERT INTO `sharecode` VALUES ('3130', 'ERM ', 'Euromoney Institutional Investor   ');
INSERT INTO `sharecode` VALUES ('3131', 'EUT ', 'European Investment Trust   ');
INSERT INTO `sharecode` VALUES ('3132', 'EVR ', 'Evraz     ');
INSERT INTO `sharecode` VALUES ('3133', 'EXI ', 'Exillon Energy    ');
INSERT INTO `sharecode` VALUES ('3134', 'EXO ', 'Exova Group    ');
INSERT INTO `sharecode` VALUES ('3135', 'EXPN', 'Experian     ');
INSERT INTO `sharecode` VALUES ('3136', 'FCI ', 'F&C Capital & Income Inv Trust');
INSERT INTO `sharecode` VALUES ('3137', 'FCPT', 'F&C Commercial Property Trust Ltd. ');
INSERT INTO `sharecode` VALUES ('3138', 'FCS ', 'F&C Global Smaller Companies  ');
INSERT INTO `sharecode` VALUES ('3139', 'FPEO', 'F&C Private Equity Trust  ');
INSERT INTO `sharecode` VALUES ('3140', 'FCRE', 'F&C UK Real Estate Investments L..');
INSERT INTO `sharecode` VALUES ('3141', 'FDM ', 'FDM Group (Holdings)   ');
INSERT INTO `sharecode` VALUES ('3142', 'FENR', 'Fenner     ');
INSERT INTO `sharecode` VALUES ('3143', 'FXPO', 'Ferrexpo     ');
INSERT INTO `sharecode` VALUES ('3144', 'FAS ', 'Fidelity Asian Values   ');
INSERT INTO `sharecode` VALUES ('3145', 'FCSS', 'Fidelity China Special Situations  ');
INSERT INTO `sharecode` VALUES ('3146', 'FEV ', 'Fidelity European Values   ');
INSERT INTO `sharecode` VALUES ('3147', 'FJV ', 'Fidelity Japanese Values   ');
INSERT INTO `sharecode` VALUES ('3148', 'FSV ', 'Fidelity Special Values   ');
INSERT INTO `sharecode` VALUES ('3149', 'FDSA', 'Fidessa Group    ');
INSERT INTO `sharecode` VALUES ('3150', 'FDL ', 'Findel     ');
INSERT INTO `sharecode` VALUES ('3151', 'FGT ', 'Finsbury Growth & Income Trust ');
INSERT INTO `sharecode` VALUES ('3152', 'FGP ', 'FirstGroup     ');
INSERT INTO `sharecode` VALUES ('3153', 'FSJ ', 'Fisher (James) & Sons  ');
INSERT INTO `sharecode` VALUES ('3154', 'FLYB', 'Flybe Group    ');
INSERT INTO `sharecode` VALUES ('3155', 'FRCL', 'Foreign and Colonial Inv Trust ');
INSERT INTO `sharecode` VALUES ('3156', 'FSFL', 'Foresight Solar Fund Limited  ');
INSERT INTO `sharecode` VALUES ('3157', 'FOXT', 'Foxtons Group    ');
INSERT INTO `sharecode` VALUES ('3158', 'FRES', 'Fresnillo     ');
INSERT INTO `sharecode` VALUES ('3159', 'FLG ', 'Friends Life Group Limited  ');
INSERT INTO `sharecode` VALUES ('3160', 'FSTA', 'Fuller Smith & Turner  ');
INSERT INTO `sharecode` VALUES ('3161', 'FEET', 'Fundsmith Emerging Equities Trust  ');
INSERT INTO `sharecode` VALUES ('3162', 'GFS ', 'G4S     ');
INSERT INTO `sharecode` VALUES ('3163', 'GFRD', 'Galliford Try    ');
INSERT INTO `sharecode` VALUES ('3164', 'GMD ', 'Game Digital    ');
INSERT INTO `sharecode` VALUES ('3165', 'GAW ', 'Games Workshop Group   ');
INSERT INTO `sharecode` VALUES ('3166', 'GCP ', 'GCP Infrastructure Investments Ltd  ');
INSERT INTO `sharecode` VALUES ('3167', 'GEMD', 'Gem Diamonds Ltd. (DI)  ');
INSERT INTO `sharecode` VALUES ('3168', 'GSS ', 'Genesis Emerging Markets Fund Lt.. ');
INSERT INTO `sharecode` VALUES ('3169', 'GNS ', 'Genus     ');
INSERT INTO `sharecode` VALUES ('3170', 'GKN ', 'GKN     ');
INSERT INTO `sharecode` VALUES ('3171', 'GSK ', 'GlaxoSmithKline     ');
INSERT INTO `sharecode` VALUES ('3172', 'GLE ', 'Gleeson (M J) Group  ');
INSERT INTO `sharecode` VALUES ('3173', 'GLEN', 'Glencore     ');
INSERT INTO `sharecode` VALUES ('3174', 'GOG ', 'Go-Ahead Group    ');
INSERT INTO `sharecode` VALUES ('3175', 'GDWN', 'Goodwin Plc    ');
INSERT INTO `sharecode` VALUES ('3176', 'GFTU', 'Grafton Group Units   ');
INSERT INTO `sharecode` VALUES ('3177', 'GRI ', 'Grainger     ');
INSERT INTO `sharecode` VALUES ('3178', 'GPE ', 'Graphite Enterprise Trust   ');
INSERT INTO `sharecode` VALUES ('3179', 'GPOR', 'Great Portland Estates   ');
INSERT INTO `sharecode` VALUES ('3180', 'UKW ', 'Greencoat UK Wind   ');
INSERT INTO `sharecode` VALUES ('3181', 'GNC ', 'Greencore Group    ');
INSERT INTO `sharecode` VALUES ('3182', 'GNK ', 'Greene King    ');
INSERT INTO `sharecode` VALUES ('3183', 'GRG ', 'Greggs     ');
INSERT INTO `sharecode` VALUES ('3184', 'GMS ', 'Gulf Marine Services   ');
INSERT INTO `sharecode` VALUES ('3185', 'HFD ', 'Halfords Group    ');
INSERT INTO `sharecode` VALUES ('3186', 'HLMA', 'Halma     ');
INSERT INTO `sharecode` VALUES ('3187', 'HMSO', 'Hammerson     ');
INSERT INTO `sharecode` VALUES ('3188', 'HAN ', 'Hansa Trust    ');
INSERT INTO `sharecode` VALUES ('3189', 'HSD ', 'Hansard Global    ');
INSERT INTO `sharecode` VALUES ('3190', 'HSTN', 'Hansteen Holdings    ');
INSERT INTO `sharecode` VALUES ('3191', 'HDY ', 'Hardy Oil & Gas  ');
INSERT INTO `sharecode` VALUES ('3192', 'HL  ', 'Hargreaves Lansdown    ');
INSERT INTO `sharecode` VALUES ('3193', 'HAS ', 'Hays     ');
INSERT INTO `sharecode` VALUES ('3194', 'HLCL', 'Helical Bar    ');
INSERT INTO `sharecode` VALUES ('3195', 'HTY ', 'Hellermanntyton Group    ');
INSERT INTO `sharecode` VALUES ('3196', 'HDIV', 'Henderson Diversified Income Ltd.  ');
INSERT INTO `sharecode` VALUES ('3197', 'HEFT', 'Henderson European Focus Trust  ');
INSERT INTO `sharecode` VALUES ('3198', 'HNE ', 'Henderson EuroTrust    ');
INSERT INTO `sharecode` VALUES ('3199', 'HFEL', 'Henderson Far East Income Ltd. ');
INSERT INTO `sharecode` VALUES ('3200', 'HGL ', 'Henderson Global Trust   ');
INSERT INTO `sharecode` VALUES ('3201', 'HGG ', 'Henderson Group    ');
INSERT INTO `sharecode` VALUES ('3202', 'HHI ', 'Henderson High Income Trust  ');
INSERT INTO `sharecode` VALUES ('3203', 'HSL ', 'Henderson Smaller Companies Inv .. ');
INSERT INTO `sharecode` VALUES ('3204', 'HVTR', 'Henderson Value Trust   ');
INSERT INTO `sharecode` VALUES ('3205', 'BHY ', 'Henry Boot    ');
INSERT INTO `sharecode` VALUES ('3206', 'HRI ', 'Herald Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3207', 'HGT ', 'HGCapital Trust    ');
INSERT INTO `sharecode` VALUES ('3208', 'HICL', 'HICL Infrastructure Company Ltd  ');
INSERT INTO `sharecode` VALUES ('3209', 'HIK ', 'Hikma Pharmaceuticals    ');
INSERT INTO `sharecode` VALUES ('3210', 'HILS', 'Hill & Smith Holdings  ');
INSERT INTO `sharecode` VALUES ('3211', 'HFG ', 'Hilton Food Group   ');
INSERT INTO `sharecode` VALUES ('3212', 'HSX ', 'Hiscox Ltd (CDI)   ');
INSERT INTO `sharecode` VALUES ('3213', 'HOC ', 'Hochschild Mining    ');
INSERT INTO `sharecode` VALUES ('3214', 'HRG ', 'Hogg Robinson Group   ');
INSERT INTO `sharecode` VALUES ('3215', 'HOME', 'Home Retail Group   ');
INSERT INTO `sharecode` VALUES ('3216', 'HSV ', 'Homeserve     ');
INSERT INTO `sharecode` VALUES ('3217', 'HWDN', 'Howden Joinery Group   ');
INSERT INTO `sharecode` VALUES ('3218', 'HSBA', 'HSBC Holdings    ');
INSERT INTO `sharecode` VALUES ('3219', 'HTG ', 'Hunting     ');
INSERT INTO `sharecode` VALUES ('3220', 'HNT ', 'Huntsworth     ');
INSERT INTO `sharecode` VALUES ('3221', 'IAP ', 'ICAP     ');
INSERT INTO `sharecode` VALUES ('3222', 'LBOW', 'ICG-Longbow Senior Secured UK Pr.. ');
INSERT INTO `sharecode` VALUES ('3223', 'IGG ', 'IG Group Holdings   ');
INSERT INTO `sharecode` VALUES ('3224', 'IMG ', 'Imagination Technologies Group   ');
INSERT INTO `sharecode` VALUES ('3225', 'IMI ', 'IMI     ');
INSERT INTO `sharecode` VALUES ('3226', 'IEM ', 'Impax Environmental Markets   ');
INSERT INTO `sharecode` VALUES ('3227', 'IMT ', 'Imperial Tobacco Group   ');
INSERT INTO `sharecode` VALUES ('3228', 'INCH', 'Inchcape     ');
INSERT INTO `sharecode` VALUES ('3229', 'INFI', 'Infinis Energy    ');
INSERT INTO `sharecode` VALUES ('3230', 'INF ', 'Informa     ');
INSERT INTO `sharecode` VALUES ('3231', 'ISAT', 'Inmarsat     ');
INSERT INTO `sharecode` VALUES ('3232', 'TIG ', 'Innovation Group    ');
INSERT INTO `sharecode` VALUES ('3233', 'IHG ', 'InterContinental Hotels Group   ');
INSERT INTO `sharecode` VALUES ('3234', 'ICP ', 'Intermediate Capital Group   ');
INSERT INTO `sharecode` VALUES ('3235', 'IBT ', 'International Biotech Trust   ');
INSERT INTO `sharecode` VALUES ('3236', 'IAG ', 'International Consolidated Airli..   ');
INSERT INTO `sharecode` VALUES ('3237', 'IPF ', 'International Personal Finance   ');
INSERT INTO `sharecode` VALUES ('3238', 'INPP', 'International Public Partnership..   ');
INSERT INTO `sharecode` VALUES ('3239', 'IRV ', 'Interserve     ');
INSERT INTO `sharecode` VALUES ('3240', 'ITRK', 'Intertek Group    ');
INSERT INTO `sharecode` VALUES ('3241', 'INTU', 'Intu Properties    ');
INSERT INTO `sharecode` VALUES ('3242', 'IAT ', 'Invesco Asia Trust   ');
INSERT INTO `sharecode` VALUES ('3243', 'IVI ', 'Invesco Income Growth Trust  ');
INSERT INTO `sharecode` VALUES ('3244', 'IPU ', 'Invesco Perpetual UK Small Compa.. ');
INSERT INTO `sharecode` VALUES ('3245', 'INVP', 'Investec     ');
INSERT INTO `sharecode` VALUES ('3246', 'IPO ', 'IP Group    ');
INSERT INTO `sharecode` VALUES ('3247', 'ITE ', 'ITE Group    ');
INSERT INTO `sharecode` VALUES ('3248', 'ITV ', 'ITV     ');
INSERT INTO `sharecode` VALUES ('3249', 'JLT ', 'Jardine Lloyd Thompson Group  ');
INSERT INTO `sharecode` VALUES ('3250', 'JD  ', 'JD Sports Fashion   ');
INSERT INTO `sharecode` VALUES ('3251', 'JKX ', 'JKX Oil & Gas  ');
INSERT INTO `sharecode` VALUES ('3252', 'JLEN', 'John Laing Environmental Assets .. ');
INSERT INTO `sharecode` VALUES ('3253', 'JLIF', 'John Laing Infrastructure Fund Ltd ');
INSERT INTO `sharecode` VALUES ('3254', 'JMAT', 'Johnson Matthey    ');
INSERT INTO `sharecode` VALUES ('3255', 'JPR ', 'Johnston Press    ');
INSERT INTO `sharecode` VALUES ('3256', 'JAM ', 'JPMorgan American Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3257', 'JAI ', 'JPMorgan Asian Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3258', 'JMC ', 'JPMorgan Chinese Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3259', 'JCH ', 'JPMorgan Claverhouse Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3260', 'JMG ', 'JPMorgan Emerging Markets Inv Tr.. ');
INSERT INTO `sharecode` VALUES ('3261', 'JESC', 'JPMorgan Euro Small Co. Trust ');
INSERT INTO `sharecode` VALUES ('3262', 'JETG', 'JPMorgan European Inv Trust Grow.. ');
INSERT INTO `sharecode` VALUES ('3263', 'JETI', 'JPMorgan European Investment Trust  ');
INSERT INTO `sharecode` VALUES ('3264', 'JGCI', 'JPMorgan Global Convertibles Inc..  ');
INSERT INTO `sharecode` VALUES ('3265', 'JEMI', 'JPMorgan Global Markets Emerging..  ');
INSERT INTO `sharecode` VALUES ('3266', 'JII ', 'JPMorgan Indian Investment Trust  ');
INSERT INTO `sharecode` VALUES ('3267', 'JPS ', 'JPMorgan Japan Smaller Companies..  ');
INSERT INTO `sharecode` VALUES ('3268', 'JFJ ', 'JPMorgan Japanese Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3269', 'JMF ', 'JPMorgan Mid Cap Inv Trust ');
INSERT INTO `sharecode` VALUES ('3270', 'JMO ', 'JPMorgan Overseas Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3271', 'JRS ', 'JPMorgan Russian Securities   ');
INSERT INTO `sharecode` VALUES ('3272', 'JMI ', 'JPMorgan Smaller Companies Inv T.. ');
INSERT INTO `sharecode` VALUES ('3273', 'JEO ', 'Jupiter European Opportunities T..  ');
INSERT INTO `sharecode` VALUES ('3274', 'JUP ', 'Jupiter Fund Management   ');
INSERT INTO `sharecode` VALUES ('3275', 'JUS ', 'Jupiter US Smaller Companies  ');
INSERT INTO `sharecode` VALUES ('3276', 'JE  ', 'Just Eat    ');
INSERT INTO `sharecode` VALUES ('3277', 'JRG ', 'Just Retirement Group   ');
INSERT INTO `sharecode` VALUES ('3278', 'KAZ ', 'Kazakhmys     ');
INSERT INTO `sharecode` VALUES ('3279', 'KCOM', 'KCOM Group    ');
INSERT INTO `sharecode` VALUES ('3280', 'KLR ', 'Keller Group    ');
INSERT INTO `sharecode` VALUES ('3281', 'KMR ', 'Kenmare Resources    ');
INSERT INTO `sharecode` VALUES ('3282', 'KWE ', 'Kennedy Wilson Europe Real Estate ');
INSERT INTO `sharecode` VALUES ('3283', 'KIT ', 'Keystone Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3284', 'KIE ', 'Kier Group    ');
INSERT INTO `sharecode` VALUES ('3285', 'KGF ', 'Kingfisher     ');
INSERT INTO `sharecode` VALUES ('3286', 'KFX ', 'Kofax Limited (DI)   ');
INSERT INTO `sharecode` VALUES ('3287', 'LAD ', 'Ladbrokes     ');
INSERT INTO `sharecode` VALUES ('3288', 'LRD ', 'Laird     ');
INSERT INTO `sharecode` VALUES ('3289', 'LAM ', 'Lamprell     ');
INSERT INTO `sharecode` VALUES ('3290', 'LRE ', 'Lancashire Holdings Limited   ');
INSERT INTO `sharecode` VALUES ('3291', 'LAND', 'Land Securities Group   ');
INSERT INTO `sharecode` VALUES ('3292', 'LVD ', 'Lavendon Group    ');
INSERT INTO `sharecode` VALUES ('3293', 'LWDB', 'Law Debenture Corp.   ');
INSERT INTO `sharecode` VALUES ('3294', 'LGEN', 'Legal & General Group  ');
INSERT INTO `sharecode` VALUES ('3295', 'LIO ', 'Liontrust Asset Management   ');
INSERT INTO `sharecode` VALUES ('3296', 'LLOY', 'Lloyds Banking Group   ');
INSERT INTO `sharecode` VALUES ('3297', 'LMS ', 'LMS Capital    ');
INSERT INTO `sharecode` VALUES ('3298', 'LSLI', 'London & St lawrence Inv Co.');
INSERT INTO `sharecode` VALUES ('3299', 'LSE ', 'London Stock Exchange Group  ');
INSERT INTO `sharecode` VALUES ('3300', 'LMP ', 'LondonMetric Property    ');
INSERT INTO `sharecode` VALUES ('3301', 'LMI ', 'Lonmin     ');
INSERT INTO `sharecode` VALUES ('3302', 'LOOK', 'Lookers     ');
INSERT INTO `sharecode` VALUES ('3303', 'LWB ', 'Low & Bonar   ');
INSERT INTO `sharecode` VALUES ('3304', 'LWI ', 'Lowland Investment Co   ');
INSERT INTO `sharecode` VALUES ('3305', 'LSL ', 'LSL Property Services   ');
INSERT INTO `sharecode` VALUES ('3306', 'MPO ', 'Macau Property Opportunities Fun..  ');
INSERT INTO `sharecode` VALUES ('3307', 'MAJE', 'Majedie Investments    ');
INSERT INTO `sharecode` VALUES ('3308', 'EMG ', 'Man Group    ');
INSERT INTO `sharecode` VALUES ('3309', 'MMC ', 'Management Consulting Group   ');
INSERT INTO `sharecode` VALUES ('3310', 'MKS ', 'Marks & Spencer Group  ');
INSERT INTO `sharecode` VALUES ('3311', 'MSLH', 'Marshalls     ');
INSERT INTO `sharecode` VALUES ('3312', 'MARS', 'Marston\'s     ');
INSERT INTO `sharecode` VALUES ('3313', 'MNP ', 'Martin Currie Global Portfolio T.. ');
INSERT INTO `sharecode` VALUES ('3314', 'MCP ', 'Martin Currie Pacific Trust  ');
INSERT INTO `sharecode` VALUES ('3315', 'MCB ', 'Mcbride     ');
INSERT INTO `sharecode` VALUES ('3316', 'MCLS', 'McColl\'s Retail Group   ');
INSERT INTO `sharecode` VALUES ('3317', 'MCKS', 'Mckay Securities    ');
INSERT INTO `sharecode` VALUES ('3318', 'MER ', 'Mears Group    ');
INSERT INTO `sharecode` VALUES ('3319', 'MEC ', 'Mecom Group    ');
INSERT INTO `sharecode` VALUES ('3320', 'MXF ', 'MedicX Fund Ltd.   ');
INSERT INTO `sharecode` VALUES ('3321', 'MGGT', 'Meggitt     ');
INSERT INTO `sharecode` VALUES ('3322', 'MRO ', 'Melrose Industries    ');
INSERT INTO `sharecode` VALUES ('3323', 'MNZS', 'Menzies(John)     ');
INSERT INTO `sharecode` VALUES ('3324', 'MRC ', 'Mercantile Investment Trust (The)  ');
INSERT INTO `sharecode` VALUES ('3325', 'MRCH', 'Merchants Trust    ');
INSERT INTO `sharecode` VALUES ('3326', 'MERL', 'Merlin Entertainments    ');
INSERT INTO `sharecode` VALUES ('3327', 'MPI ', 'Michael Page International   ');
INSERT INTO `sharecode` VALUES ('3328', 'MCRO', 'Micro Focus International   ');
INSERT INTO `sharecode` VALUES ('3329', 'MLC ', 'Millennium & Copthorne Hotels  ');
INSERT INTO `sharecode` VALUES ('3330', 'MAB ', 'Mitchells & Butlers   ');
INSERT INTO `sharecode` VALUES ('3331', 'MTO ', 'Mitie Group    ');
INSERT INTO `sharecode` VALUES ('3332', 'MNDI', 'Mondi     ');
INSERT INTO `sharecode` VALUES ('3333', 'MONY', 'Moneysupermarket.com Group    ');
INSERT INTO `sharecode` VALUES ('3334', 'MNKS', 'Monks Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3335', 'MTE ', 'Montanaro European Smaller Compa..  ');
INSERT INTO `sharecode` VALUES ('3336', 'MTU ', 'Montanaro UK Smaller Companies I.. ');
INSERT INTO `sharecode` VALUES ('3337', 'MGAM', 'Morgan Advanced Materials   ');
INSERT INTO `sharecode` VALUES ('3338', 'MGNS', 'Morgan Sindall Group   ');
INSERT INTO `sharecode` VALUES ('3339', 'MRW ', 'Morrison (Wm) Supermarkets   ');
INSERT INTO `sharecode` VALUES ('3340', 'MOSB', 'Moss Bros Group   ');
INSERT INTO `sharecode` VALUES ('3341', 'MTC ', 'Mothercare     ');
INSERT INTO `sharecode` VALUES ('3342', 'MTVW', 'Mountview Estates    ');
INSERT INTO `sharecode` VALUES ('3343', 'MUT ', 'Murray Income Trust   ');
INSERT INTO `sharecode` VALUES ('3344', 'MYI ', 'Murray International Trust   ');
INSERT INTO `sharecode` VALUES ('3345', 'NEX ', 'National Express Group   ');
INSERT INTO `sharecode` VALUES ('3346', 'NG  ', 'National Grid    ');
INSERT INTO `sharecode` VALUES ('3347', 'NBLS', 'NB Global Floating Rate Income F..');
INSERT INTO `sharecode` VALUES ('3348', 'NCC ', 'NCC Group    ');
INSERT INTO `sharecode` VALUES ('3349', 'NCYF', 'New City High Yield Fund Ltd.');
INSERT INTO `sharecode` VALUES ('3350', 'NII ', 'New India Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3351', 'NXT ', 'Next     ');
INSERT INTO `sharecode` VALUES ('3352', 'NMC ', 'NMC Health    ');
INSERT INTO `sharecode` VALUES ('3353', 'NXR ', 'Norcros     ');
INSERT INTO `sharecode` VALUES ('3354', 'NAIT', 'North American Income Trust (The) ');
INSERT INTO `sharecode` VALUES ('3355', 'NAS ', 'North Atlantic Smaller Companies..  ');
INSERT INTO `sharecode` VALUES ('3356', 'NTG ', 'Northgate     ');
INSERT INTO `sharecode` VALUES ('3357', 'NOG ', 'Nostrum Oil & Gas  ');
INSERT INTO `sharecode` VALUES ('3358', 'NVA ', 'Novae Group    ');
INSERT INTO `sharecode` VALUES ('3359', 'OCDO', 'Ocado Group    ');
INSERT INTO `sharecode` VALUES ('3360', 'OML ', 'Old Mutual    ');
INSERT INTO `sharecode` VALUES ('3361', 'OSB ', 'OneSavings Bank    ');
INSERT INTO `sharecode` VALUES ('3362', 'OPHR', 'Ophir Energy    ');
INSERT INTO `sharecode` VALUES ('3363', 'OPTS', 'Optos     ');
INSERT INTO `sharecode` VALUES ('3364', 'OXIG', 'Oxford Instruments    ');
INSERT INTO `sharecode` VALUES ('3365', 'P2P ', 'P2P Global Investments   ');
INSERT INTO `sharecode` VALUES ('3366', 'PIC ', 'Pace     ');
INSERT INTO `sharecode` VALUES ('3367', 'PAC ', 'Pacific Assets Trust   ');
INSERT INTO `sharecode` VALUES ('3368', 'PHI ', 'Pacific Horizon Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3369', 'PIN ', 'Pantheon International Participa..   ');
INSERT INTO `sharecode` VALUES ('3370', 'PAG ', 'Paragon Group Of Companies  ');
INSERT INTO `sharecode` VALUES ('3371', 'PA  ', 'Partnership Assurance Group   ');
INSERT INTO `sharecode` VALUES ('3372', 'PAY ', 'PayPoint     ');
INSERT INTO `sharecode` VALUES ('3373', 'PSON', 'Pearson     ');
INSERT INTO `sharecode` VALUES ('3374', 'PDG ', 'Pendragon     ');
INSERT INTO `sharecode` VALUES ('3375', 'PNN ', 'Pennon Group    ');
INSERT INTO `sharecode` VALUES ('3376', 'PER ', 'Perform Group    ');
INSERT INTO `sharecode` VALUES ('3377', 'PLI ', 'Perpetual Income & Growth Inv Tr..');
INSERT INTO `sharecode` VALUES ('3378', 'PSN ', 'Persimmon     ');
INSERT INTO `sharecode` VALUES ('3379', 'PNL ', 'Personal Assets Trust   ');
INSERT INTO `sharecode` VALUES ('3380', 'PDL ', 'Petra Diamonds Ltd.(DI)   ');
INSERT INTO `sharecode` VALUES ('3381', 'PFC ', 'Petrofac Ltd.    ');
INSERT INTO `sharecode` VALUES ('3382', 'POG ', 'Petropavlovsk     ');
INSERT INTO `sharecode` VALUES ('3383', 'PETS', 'Pets at Home Group  ');
INSERT INTO `sharecode` VALUES ('3384', 'PHNX', 'Phoenix Group Holdings (DI)  ');
INSERT INTO `sharecode` VALUES ('3385', 'PHTM', 'Photo-Me International    ');
INSERT INTO `sharecode` VALUES ('3386', 'PCTN', 'Picton Property Income Ltd  ');
INSERT INTO `sharecode` VALUES ('3387', 'PTEC', 'Playtech     ');
INSERT INTO `sharecode` VALUES ('3388', 'PCFT', 'Polar Capital Global Financials .. ');
INSERT INTO `sharecode` VALUES ('3389', 'PCGH', 'Polar Capital Global Healthcare .. ');
INSERT INTO `sharecode` VALUES ('3390', 'PCT ', 'Polar Capital Technology Trust  ');
INSERT INTO `sharecode` VALUES ('3391', 'POLY', 'Polymetal International    ');
INSERT INTO `sharecode` VALUES ('3392', 'PLP ', 'Polypipe Group    ');
INSERT INTO `sharecode` VALUES ('3393', 'PRV ', 'Porvair     ');
INSERT INTO `sharecode` VALUES ('3394', 'PLND', 'Poundland Group    ');
INSERT INTO `sharecode` VALUES ('3395', 'PFL ', 'Premier Farnell    ');
INSERT INTO `sharecode` VALUES ('3396', 'PFD ', 'Premier Foods    ');
INSERT INTO `sharecode` VALUES ('3397', 'PMO ', 'Premier Oil    ');
INSERT INTO `sharecode` VALUES ('3398', 'PHP ', 'Primary Health Properties   ');
INSERT INTO `sharecode` VALUES ('3399', 'PFG ', 'Provident Financial    ');
INSERT INTO `sharecode` VALUES ('3400', 'PRU ', 'Prudential     ');
INSERT INTO `sharecode` VALUES ('3401', 'PUB ', 'Punch Taverns    ');
INSERT INTO `sharecode` VALUES ('3402', 'PZC ', 'PZ Cussons    ');
INSERT INTO `sharecode` VALUES ('3403', 'QQ  ', 'QinetiQ Group    ');
INSERT INTO `sharecode` VALUES ('3404', 'QED ', 'Quintain Estates & Development  ');
INSERT INTO `sharecode` VALUES ('3405', 'RRS ', 'Randgold Resources Ltd.   ');
INSERT INTO `sharecode` VALUES ('3406', 'RNK ', 'Rank Group    ');
INSERT INTO `sharecode` VALUES ('3407', 'RAT ', 'Rathbone Brothers    ');
INSERT INTO `sharecode` VALUES ('3408', 'RUS ', 'Raven Russia Ltd   ');
INSERT INTO `sharecode` VALUES ('3409', 'RECI', 'Real Estate Credit Investments P.. ');
INSERT INTO `sharecode` VALUES ('3410', 'RB  ', 'Reckitt Benckiser Group   ');
INSERT INTO `sharecode` VALUES ('3411', 'RDI ', 'Redefine International    ');
INSERT INTO `sharecode` VALUES ('3412', 'RDW ', 'Redrow     ');
INSERT INTO `sharecode` VALUES ('3413', 'REL ', 'Reed Elsevier    ');
INSERT INTO `sharecode` VALUES ('3414', 'RGU ', 'Regus     ');
INSERT INTO `sharecode` VALUES ('3415', 'RSW ', 'Renishaw     ');
INSERT INTO `sharecode` VALUES ('3416', 'RNO ', 'Renold     ');
INSERT INTO `sharecode` VALUES ('3417', 'RTO ', 'Rentokil Initial    ');
INSERT INTO `sharecode` VALUES ('3418', 'RTN ', 'Restaurant Group    ');
INSERT INTO `sharecode` VALUES ('3419', 'REX ', 'Rexam     ');
INSERT INTO `sharecode` VALUES ('3420', 'RCDO', 'Ricardo     ');
INSERT INTO `sharecode` VALUES ('3421', 'RMV ', 'Rightmove     ');
INSERT INTO `sharecode` VALUES ('3422', 'RIO ', 'Rio Tinto    ');
INSERT INTO `sharecode` VALUES ('3423', 'RCP ', 'RIT Capital Partners   ');
INSERT INTO `sharecode` VALUES ('3424', 'RSE ', 'Riverstone Energy Limited   ');
INSERT INTO `sharecode` VALUES ('3425', 'RM  ', 'RM     ');
INSERT INTO `sharecode` VALUES ('3426', 'RWA ', 'Robert Walters    ');
INSERT INTO `sharecode` VALUES ('3427', 'RR  ', 'Rolls-Royce Holdings    ');
INSERT INTO `sharecode` VALUES ('3428', 'ROR ', 'Rotork     ');
INSERT INTO `sharecode` VALUES ('3429', 'RBS ', 'Royal Bank of Scotland Group ');
INSERT INTO `sharecode` VALUES ('3430', 'RDSA', 'Royal Dutch Shell \'A\'  ');
INSERT INTO `sharecode` VALUES ('3431', 'RDSB', 'Royal Dutch Shell \'B\'  ');
INSERT INTO `sharecode` VALUES ('3432', 'RMG ', 'Royal Mail    ');
INSERT INTO `sharecode` VALUES ('3433', 'RPC ', 'RPC Group    ');
INSERT INTO `sharecode` VALUES ('3434', 'RPS ', 'RPS Group    ');
INSERT INTO `sharecode` VALUES ('3435', 'RSA ', 'RSA Insurance Group   ');
INSERT INTO `sharecode` VALUES ('3436', 'RICA', 'Ruffer Investment Company Ltd Re.. ');
INSERT INTO `sharecode` VALUES ('3437', 'SUS ', 'S&U     ');
INSERT INTO `sharecode` VALUES ('3438', 'SAB ', 'SABMiller     ');
INSERT INTO `sharecode` VALUES ('3439', 'SAFE', 'Safestore Holdings    ');
INSERT INTO `sharecode` VALUES ('3440', 'SAGA', 'Saga     ');
INSERT INTO `sharecode` VALUES ('3441', 'SGE ', 'Sage Group    ');
INSERT INTO `sharecode` VALUES ('3442', 'SBRY', 'Sainsbury (J)    ');
INSERT INTO `sharecode` VALUES ('3443', 'SMDR', 'Salamander Energy    ');
INSERT INTO `sharecode` VALUES ('3444', 'SVS ', 'Savills     ');
INSERT INTO `sharecode` VALUES ('3445', 'SDP ', 'Schroder Asia Pacific Fund  ');
INSERT INTO `sharecode` VALUES ('3446', 'SCF ', 'Schroder Income Growth Fund  ');
INSERT INTO `sharecode` VALUES ('3447', 'SJG ', 'Schroder Japan Growth Fund  ');
INSERT INTO `sharecode` VALUES ('3448', 'SOI ', 'Schroder Oriental Income Fund Ltd. ');
INSERT INTO `sharecode` VALUES ('3449', 'SREI', 'Schroder Real Estate Investment .. ');
INSERT INTO `sharecode` VALUES ('3450', 'SDU ', 'Schroder UK Growth Fund  ');
INSERT INTO `sharecode` VALUES ('3451', 'SCP ', 'Schroder UK Mid Cap Fund ');
INSERT INTO `sharecode` VALUES ('3452', 'SDR ', 'Schroders     ');
INSERT INTO `sharecode` VALUES ('3453', 'SCAM', 'Scottish American Inv Company  ');
INSERT INTO `sharecode` VALUES ('3454', 'SCIN', 'Scottish Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3455', 'SMT ', 'Scottish Mortgage Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3456', 'SST ', 'Scottish Oriental Smaller Compan..  ');
INSERT INTO `sharecode` VALUES ('3457', 'SDL ', 'SDL     ');
INSERT INTO `sharecode` VALUES ('3458', 'STS ', 'Securities Trust of Scotland  ');
INSERT INTO `sharecode` VALUES ('3459', 'SGRO', 'SEGRO     ');
INSERT INTO `sharecode` VALUES ('3460', 'SNR ', 'Senior     ');
INSERT INTO `sharecode` VALUES ('3461', 'SEPU', 'Sepura     ');
INSERT INTO `sharecode` VALUES ('3462', 'SRP ', 'Serco Group    ');
INSERT INTO `sharecode` VALUES ('3463', 'SERV', 'Servelec Group    ');
INSERT INTO `sharecode` VALUES ('3464', 'SFR ', 'Severfield     ');
INSERT INTO `sharecode` VALUES ('3465', 'SVT ', 'Severn Trent    ');
INSERT INTO `sharecode` VALUES ('3466', 'SHB ', 'Shaftesbury     ');
INSERT INTO `sharecode` VALUES ('3467', 'SKS ', 'Shanks Group    ');
INSERT INTO `sharecode` VALUES ('3468', 'SHP ', 'Shire Plc    ');
INSERT INTO `sharecode` VALUES ('3469', 'SHRS', 'Shires Income    ');
INSERT INTO `sharecode` VALUES ('3470', 'SHI ', 'SIG     ');
INSERT INTO `sharecode` VALUES ('3471', 'SKP ', 'Skyepharma     ');
INSERT INTO `sharecode` VALUES ('3472', 'SN  ', 'Smith & Nephew   ');
INSERT INTO `sharecode` VALUES ('3473', 'SMDS', 'Smith (DS)    ');
INSERT INTO `sharecode` VALUES ('3474', 'SMIN', 'Smiths Group    ');
INSERT INTO `sharecode` VALUES ('3475', 'SIA ', 'Soco International    ');
INSERT INTO `sharecode` VALUES ('3476', 'SXS ', 'Spectris     ');
INSERT INTO `sharecode` VALUES ('3477', 'SDY ', 'Speedy Hire    ');
INSERT INTO `sharecode` VALUES ('3478', 'SPX ', 'Spirax-Sarco Engineering    ');
INSERT INTO `sharecode` VALUES ('3479', 'SPI ', 'Spire Healthcare Group   ');
INSERT INTO `sharecode` VALUES ('3480', 'SPT ', 'Spirent Communications    ');
INSERT INTO `sharecode` VALUES ('3481', 'SPRT', 'Spirit Pub Company   ');
INSERT INTO `sharecode` VALUES ('3482', 'SPO ', 'Sportech     ');
INSERT INTO `sharecode` VALUES ('3483', 'SPD ', 'Sports Direct International   ');
INSERT INTO `sharecode` VALUES ('3484', 'SQN ', 'SQN Asset Finance Income Fund Li..');
INSERT INTO `sharecode` VALUES ('3485', 'SSE ', 'SSE     ');
INSERT INTO `sharecode` VALUES ('3486', 'SSPG', 'SSP Group    ');
INSERT INTO `sharecode` VALUES ('3487', 'SIV ', 'St Ives    ');
INSERT INTO `sharecode` VALUES ('3488', 'STJ ', 'St James\'s Place   ');
INSERT INTO `sharecode` VALUES ('3489', 'SMP ', 'St. Modwen Properties   ');
INSERT INTO `sharecode` VALUES ('3490', 'SGC ', 'Stagecoach Group    ');
INSERT INTO `sharecode` VALUES ('3491', 'STAN', 'Standard Chartered    ');
INSERT INTO `sharecode` VALUES ('3492', 'SL  ', 'Standard Life    ');
INSERT INTO `sharecode` VALUES ('3493', 'SLET', 'Standard Life Equity Income Trust ');
INSERT INTO `sharecode` VALUES ('3494', 'SEP ', 'Standard Life European Private E.. ');
INSERT INTO `sharecode` VALUES ('3495', 'SLI ', 'Standard Life Investments Proper..  ');
INSERT INTO `sharecode` VALUES ('3496', 'SLS ', 'Standard Life UK Smaller Compani.. ');
INSERT INTO `sharecode` VALUES ('3497', 'SWEF', 'Starwood European Real Estate Fi.. ');
INSERT INTO `sharecode` VALUES ('3498', 'STHR', 'SThree     ');
INSERT INTO `sharecode` VALUES ('3499', 'STOB', 'Stobart Group Ltd.   ');
INSERT INTO `sharecode` VALUES ('3500', 'STCK', 'Stock Spirits Group   ');
INSERT INTO `sharecode` VALUES ('3501', 'STVG', 'STV Group    ');
INSERT INTO `sharecode` VALUES ('3502', 'SGP ', 'Supergroup     ');
INSERT INTO `sharecode` VALUES ('3503', 'SVI ', 'SVG Capital    ');
INSERT INTO `sharecode` VALUES ('3504', 'SYR ', 'Synergy Health    ');
INSERT INTO `sharecode` VALUES ('3505', 'SYNT', 'Synthomer     ');
INSERT INTO `sharecode` VALUES ('3506', 'TALK', 'TalkTalk Telecom Group   ');
INSERT INTO `sharecode` VALUES ('3507', 'TRS ', 'Tarsus Group    ');
INSERT INTO `sharecode` VALUES ('3508', 'TATE', 'Tate & Lyle   ');
INSERT INTO `sharecode` VALUES ('3509', 'TW  ', 'Taylor Wimpey    ');
INSERT INTO `sharecode` VALUES ('3510', 'TED ', 'Ted Baker    ');
INSERT INTO `sharecode` VALUES ('3511', 'TCY ', 'Telecity Group    ');
INSERT INTO `sharecode` VALUES ('3512', 'TEP ', 'Telecom Plus    ');
INSERT INTO `sharecode` VALUES ('3513', 'TMPL', 'Temple Bar Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3514', 'TEM ', 'Templeton Emerging Markets Inv T.. ');
INSERT INTO `sharecode` VALUES ('3515', 'TSCO', 'Tesco     ');
INSERT INTO `sharecode` VALUES ('3516', 'TRIG', 'The Renewables Infrastructure Gr..  ');
INSERT INTO `sharecode` VALUES ('3517', 'TCG ', 'Thomas Cook Group   ');
INSERT INTO `sharecode` VALUES ('3518', 'TPT ', 'Topps Tiles    ');
INSERT INTO `sharecode` VALUES ('3519', 'TCSC', 'Town Centre Securities   ');
INSERT INTO `sharecode` VALUES ('3520', 'TRG ', 'TR European Growth Trust  ');
INSERT INTO `sharecode` VALUES ('3521', 'TRY ', 'TR Property Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3522', 'TPK ', 'Travis Perkins    ');
INSERT INTO `sharecode` VALUES ('3523', 'TRB ', 'Tribal Group    ');
INSERT INTO `sharecode` VALUES ('3524', 'TRI ', 'Trifast     ');
INSERT INTO `sharecode` VALUES ('3525', 'TNI ', 'Trinity Mirror    ');
INSERT INTO `sharecode` VALUES ('3526', 'BBOX', 'Tritax Big Box Reit  ');
INSERT INTO `sharecode` VALUES ('3527', 'TIGT', 'Troy Income & Growth Trust ');
INSERT INTO `sharecode` VALUES ('3528', 'TSB ', 'TSB Banking Group   ');
INSERT INTO `sharecode` VALUES ('3529', 'TTG ', 'TT Electronics    ');
INSERT INTO `sharecode` VALUES ('3530', 'TT  ', 'TUI Travel    ');
INSERT INTO `sharecode` VALUES ('3531', 'TLPR', 'Tullett Prebon    ');
INSERT INTO `sharecode` VALUES ('3532', 'TLW ', 'Tullow Oil    ');
INSERT INTO `sharecode` VALUES ('3533', 'TFIF', 'Twentyfour Income Fund Limited O.. ');
INSERT INTO `sharecode` VALUES ('3534', 'SMIF', 'TwentyFour Select Monthly Income..  ');
INSERT INTO `sharecode` VALUES ('3535', 'TYMN', 'Tyman     ');
INSERT INTO `sharecode` VALUES ('3536', 'UBM ', 'UBM     ');
INSERT INTO `sharecode` VALUES ('3537', 'UDG ', 'UDG Healthcare Public Limited Co.. ');
INSERT INTO `sharecode` VALUES ('3538', 'UKCM', 'UK Commercial Property Trust  ');
INSERT INTO `sharecode` VALUES ('3539', 'UKM ', 'UK Mail Group   ');
INSERT INTO `sharecode` VALUES ('3540', 'ULE ', 'Ultra Electronics Holdings   ');
INSERT INTO `sharecode` VALUES ('3541', 'ULVR', 'Unilever     ');
INSERT INTO `sharecode` VALUES ('3542', 'UTG ', 'Unite Group    ');
INSERT INTO `sharecode` VALUES ('3543', 'UU  ', 'United Utilities Group   ');
INSERT INTO `sharecode` VALUES ('3544', 'UEM ', 'Utilico Emerging Markets Ltd (DI) ');
INSERT INTO `sharecode` VALUES ('3545', 'UTV ', 'UTV Media    ');
INSERT INTO `sharecode` VALUES ('3546', 'VIN ', 'Value and Income Trust  ');
INSERT INTO `sharecode` VALUES ('3547', 'VEC ', 'Vectura Group    ');
INSERT INTO `sharecode` VALUES ('3548', 'VED ', 'Vedanta Resources    ');
INSERT INTO `sharecode` VALUES ('3549', 'VSVS', 'Vesuvius     ');
INSERT INTO `sharecode` VALUES ('3550', 'VCT ', 'Victrex plc    ');
INSERT INTO `sharecode` VALUES ('3551', 'VTC ', 'Vitec Group    ');
INSERT INTO `sharecode` VALUES ('3552', 'VOD ', 'Vodafone Group    ');
INSERT INTO `sharecode` VALUES ('3553', 'FAN ', 'Volution Group (WI)   ');
INSERT INTO `sharecode` VALUES ('3554', 'VP  ', 'VP     ');
INSERT INTO `sharecode` VALUES ('3555', 'WEIR', 'Weir Group    ');
INSERT INTO `sharecode` VALUES ('3556', 'JDW ', 'Wetherspoon (J.D.)    ');
INSERT INTO `sharecode` VALUES ('3557', 'SMWH', 'WH Smith    ');
INSERT INTO `sharecode` VALUES ('3558', 'WTB ', 'Whitbread     ');
INSERT INTO `sharecode` VALUES ('3559', 'WMH ', 'William Hill    ');
INSERT INTO `sharecode` VALUES ('3560', 'WIN ', 'Wincanton     ');
INSERT INTO `sharecode` VALUES ('3561', 'WTAN', 'Witan Inv Trust   ');
INSERT INTO `sharecode` VALUES ('3562', 'WPC ', 'Witan Pacific Inv Trust  ');
INSERT INTO `sharecode` VALUES ('3563', 'WOS ', 'Wolseley     ');
INSERT INTO `sharecode` VALUES ('3564', 'WG  ', 'Wood Group (John)   ');
INSERT INTO `sharecode` VALUES ('3565', 'WKP ', 'Workspace Group    ');
INSERT INTO `sharecode` VALUES ('3566', 'WWH ', 'Worldwide Healthcare Trust   ');
INSERT INTO `sharecode` VALUES ('3567', 'WPP ', 'WPP     ');
INSERT INTO `sharecode` VALUES ('3568', 'XAR ', 'Xaar     ');
INSERT INTO `sharecode` VALUES ('3569', 'XCH ', 'Xchanging     ');
INSERT INTO `sharecode` VALUES ('3570', 'XPP ', 'XP Power Ltd. (DI)  ');
INSERT INTO `sharecode` VALUES ('3571', 'ZPLA', 'Zoopla Property Group (WI)  ');

-- ----------------------------
-- Table structure for `template`
-- ----------------------------
DROP TABLE IF EXISTS `template`;
CREATE TABLE `template` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateText` varchar(255) NOT NULL,
  `TemplateName` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=226 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of template
-- ----------------------------
INSERT INTO `template` VALUES ('90', 'good buy', 'Template2');
INSERT INTO `template` VALUES ('91', 'sky rocket', 'Template2');
INSERT INTO `template` VALUES ('92', 'rocket', 'Template2');
INSERT INTO `template` VALUES ('93', 'unbelievable', 'Template2');
INSERT INTO `template` VALUES ('94', 'massive', 'Template2');
INSERT INTO `template` VALUES ('95', 'big thing', 'Template2');
INSERT INTO `template` VALUES ('96', 'massive profit', 'Template2');
INSERT INTO `template` VALUES ('97', 'exploding', 'Template2');
INSERT INTO `template` VALUES ('218', 'imminently', 'Template1');
INSERT INTO `template` VALUES ('219', 'quickly', 'Template1');
INSERT INTO `template` VALUES ('220', 'expected', 'Template1');
INSERT INTO `template` VALUES ('221', 'hot tip', 'Template1');
INSERT INTO `template` VALUES ('222', 'critical', 'Template1');
INSERT INTO `template` VALUES ('223', 'insider', 'Template1');
INSERT INTO `template` VALUES ('224', 'recommendation', 'Template1');
INSERT INTO `template` VALUES ('225', 'big mover', 'Template1');
