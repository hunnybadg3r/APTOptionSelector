using System.Collections.ObjectModel;
using System.Windows;

namespace APTOptionSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly OptionMediator _mediator;
        private ObservableCollection<OptionItemViewModel> _options;

        public MainWindow()
        {
            InitializeComponent();
            _mediator = new OptionMediator();
            InitializeOptions();
            OptionsGrid.ItemsSource = _options;
            UpdateUI();
        }

        private void InitializeOptions()
        {
            _options = new ObservableCollection<OptionItemViewModel>
            {
                // 공간옵션
                new OptionItemViewModel { Code = "A", Category = "공간옵션", Name = "침실통합형(침실2+알파룸 통합)", Price = 0, DownPayment = 0, Interim = 0, Balance = 0 },

                // 주방가구
                new OptionItemViewModel { Code = "1-1", Category = "주방가구", Name = "냉장고장+키큰수납장(수납장+가전소물장)", Price = 497000, DownPayment = 24000, Interim = 99000, Balance = 374000 },
                new OptionItemViewModel { Code = "2", Category = "주방가구", Name = "식기세척기 공간장", Price = 1744000, DownPayment = 87000, Interim = 348000, Balance = 1309000, SelectionConstraintMessage = "※ 식기세척기 제공이 아님"},
                new OptionItemViewModel { Code = "3", Category = "주방가구", Name = "아일랜드식탁(MMA)", Price = 1744000, DownPayment = 87000, Interim = 348000, Balance = 1309000, SelectionConstraintMessage = "3 선택시 4, 5 선택 불가" },
                new OptionItemViewModel { Code = "4", Category = "주방가구", Name = "[주방특화]엔지니어드스톤 마감(주방가구 상판, 주방벽체)+디자인형 수전+사각씽크볼+상부장 하부조명", Price = 3912000, DownPayment = 195000, Interim = 782000, Balance = 2935000 },
                new OptionItemViewModel { Code = "5", Category = "주방가구", Name = "[주방특화] 아일랜드식탁(엔지니어드스톤)", Price = 1951000, DownPayment = 97000, Interim = 390000, Balance = 1464000, SelectionConstraintMessage = "4 선택 시 선택 가능(단독선택 불가)" },

                // 가구
                new OptionItemViewModel { Code = "6-1", Category = "가구", Name = "침실1 드레스룸", Price = 2266000, DownPayment = 113000, Interim = 453000, Balance = 1700000, SelectionConstraintMessage = "6-1, 6-2, 6-3 중 하나만 선택 가능" },
                new OptionItemViewModel { Code = "6-2", Category = "가구", Name = "침실1 드레스룸+붙박이장(슬라이딩형2장)+화장대", Price = 5775000, DownPayment = 288000, Interim = 1155000, Balance = 4332000, SelectionConstraintMessage = "6-1, 6-2, 6-3 중 하나만 선택 가능" },
                new OptionItemViewModel { Code = "6-3", Category = "가구", Name = "침실1 드레스룸+붙박이장(슬라이딩형3장)", Price = 5471000, DownPayment = 273000, Interim = 1094000, Balance = 4104000, SelectionConstraintMessage = "6-1, 6-2, 6-3 중 하나만 선택 가능" },
                new OptionItemViewModel { Code = "7-1", Category = "가구", Name = "침실2 붙박이장(여닫이3짝)", Price = 1488000, DownPayment = 74000, Interim = 297000, Balance = 1117000, SelectionConstraintMessage = "7-1, 7-2 중 하나만 선택가능" },
                new OptionItemViewModel { Code = "7-2", Category = "가구", Name = "통합형 붙박이장(슬라이딩형2장+장식장)", Price = 3060000, DownPayment = 153000, Interim = 612000, Balance = 2295000, SelectionConstraintMessage = "7-1, 7-2 중 하나만 선택가능"},
                new OptionItemViewModel { Code = "8-1", Category = "가구", Name = "알파룸 복도팬트리(시스템선반+가구도어)+공간\n(슬라이딩도어)", Price = 3723000, DownPayment = 186000, Interim = 744000, Balance = 2793000, SelectionConstraintMessage = "8-1, 8-2 중 하나만 선택가능, A 침실통합형 선택시 선택 불가" },
                new OptionItemViewModel { Code = "8-2", Category = "가구", Name = "알파룸 복도팬트리(시스템선반+가구도어)+\n드레스룸(시스템선반+여닫이도어)", Price = 4114000, DownPayment = 205000, Interim = 822000, Balance = 3087000, SelectionConstraintMessage = "8-1, 8-2 중 하나만 선택가능, A 침실통합형 선택시 선택 불가" },
                new OptionItemViewModel { Code = "9", Category = "가구", Name = "현관창고 시스템선반", Price = 0, DownPayment = 0, Interim = 0, Balance = 0 },
                new OptionItemViewModel { Code = "10", Category = "가구", Name = "현관 중문", Price = 1691000, DownPayment = 84000, Interim = 338000, Balance = 1269000 },
                
                // 인테리어
                new OptionItemViewModel { Code = "11", Category = "인테리어", Name = "거실 아트월 광폭타일(600*1200)", Price = 542000, DownPayment = 27000, Interim = 108000, Balance = 407000 },
                new OptionItemViewModel { Code = "12", Category = "인테리어", Name = "[거실특화] 거실 벽체 등 시트판넬 마감(아트월 맞은편,\n창문벽, 복도벽, 현관벽", Price = 3066000, DownPayment = 153000, Interim = 613000, Balance = 2300000 },
                new OptionItemViewModel { Code = "13-1", Category = "인테리어", Name = "[조명특화]거실등(중앙직부등)+간접조명(우물천장 4면+\n신발장 하부)+포인트조명(아트월)+엣지등(거실,침실1)", Price = 2000000, DownPayment = 100000, Interim = 400000, Balance = 1500000, SelectionConstraintMessage = "13-1, 13-2 중 하나만 선택가능" },
                new OptionItemViewModel { Code = "13-2", Category = "인테리어", Name = "[조명특화]거실등(다운라이트8개)+간접조명(우물천장 4면+\n신발장 하부)+포인트조명(아트월)+엣지등(거실,침실1)", Price = 2604000, DownPayment = 130000, Interim = 520000, Balance = 1954000, SelectionConstraintMessage = "13-1, 13-2 중 하나만 선택가능"  },

                // 주방가전
                new OptionItemViewModel { Code = "14-1", Category = "주방가전", Name = "가스1구+인덕션2구", Price = 700000, DownPayment = 35000, Interim = 140000, Balance = 525000, SelectionConstraintMessage = "14-1, 14-2 중 하나만 선택가능" },
                new OptionItemViewModel { Code = "14-2", Category = "주방가전", Name = "인덕션3구", Price = 600000, DownPayment = 30000, Interim = 120000, Balance = 450000, SelectionConstraintMessage = "14-1, 14-2 중 하나만 선택가능" },

                // 시스템에어컨
                new OptionItemViewModel { Code = "15-1", Category = "시스템에어컨", Name = "거실+침실1", Price = 3900000, DownPayment = 195000, Interim = 780000, Balance = 2925000, SelectionConstraintMessage = "15-1, 15-2, 15-3, 15-4 중 하나만 선택가능" },
                new OptionItemViewModel { Code = "15-2", Category = "시스템에어컨", Name = "거실+침실1+침실2", Price = 5600000, DownPayment = 280000, Interim = 1120000, Balance = 4200000, SelectionConstraintMessage = "15-1, 15-2, 15-3, 15-4 중 하나만 선택가능. 15-2는 8-1, 8-2 선택시 선택 가능" },
                new OptionItemViewModel { Code = "15-3", Category = "시스템에어컨", Name = "거실+침실1+침실2/알파룸(통합형)", Price = 5600000, DownPayment = 280000, Interim = 1120000, Balance = 4200000, SelectionConstraintMessage = "15-1, 15-2, 15-3, 15-4 중 하나만 선택가능. 15-3은 A 침실통합형 선택시 선택 가능" },
                new OptionItemViewModel { Code = "15-4", Category = "시스템에어컨", Name = "거실+침실1+침실2+알파룸", Price = 6600000, DownPayment = 330000, Interim = 1320000, Balance = 4950000, SelectionConstraintMessage = "15-1, 15-2, 15-3, 15-4 중 하나만 선택가능" },

                // 욕실자재
                new OptionItemViewModel { Code = "16-1", Category = "욕실자재", Name = "공용욕실 다기능팬", Price = 550000, DownPayment = 27000, Interim = 110000, Balance = 413000 },
                new OptionItemViewModel { Code = "16-2", Category = "욕실자재", Name = "비데일체형 양변기", Price = 0, DownPayment = 0, Interim = 0, Balance = 0 },

                // 바닥재
                new OptionItemViewModel { Code = "17", Category = "바닥재", Name = "기능성 륨카펫(6mm)", Price = 0, DownPayment = 0, Interim = 0, Balance = 0 }
            };

            foreach (var option in _options)
            {
                option.PropertyChanged += Option_PropertyChanged;
            }
        }

        private void Option_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OptionItemViewModel.IsSelected))
            {
                var option = sender as OptionItemViewModel;
                _mediator.OptionSelected(option.Code, option.IsSelected);
                UpdateUI();
            }
        }

        private void OptionCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            // 총 금액 업데이트
            decimal totalPrice = _options.Where(o => o.IsSelected).Sum(o => o.Price);
            TotalPriceText.Text = $"총 선택 금액: {totalPrice:N0} 원";

            // 선택 불가능한 옵션들 비활성화
            foreach (var option in _options)
            {
                option.IsEnabled = _mediator.CanSelectOption(option.Code);
            }
        }
    }

    public class OptionMediator
    {
        private readonly HashSet<string> _selectedOptions;
        private readonly Dictionary<string, List<string>> _constraints;
        private readonly Dictionary<string, List<string>> _prerequisites;
        private readonly Dictionary<string, List<string>> _mutuallyExclusiveGroups;

        public OptionMediator()
        {
            _selectedOptions = new HashSet<string>();
            _constraints = new Dictionary<string, List<string>>();
            _prerequisites = new Dictionary<string, List<string>>();
            _mutuallyExclusiveGroups = new Dictionary<string, List<string>>();

            InitializeConstraints();
        }

        private void InitializeConstraints()
        {
            // 주방가구 제약조건
            _constraints.Add("3", new List<string> { "4", "5" });     // 3 선택시 4, 5 선택 불가
            _prerequisites.Add("5", new List<string> { "4" });        // 5는 4 선택시에만 선택 가능

            // 침실1 드레스룸 상호배타적 그룹
            _mutuallyExclusiveGroups.Add("침실1드레스룸", new List<string> { "6-1", "6-2", "6-3" });

            // 침실2 붙박이장 상호배타적 그룹
            _mutuallyExclusiveGroups.Add("침실2붙박이장", new List<string> { "7-1", "7-2" });

            // 알파룸 상호배타적 그룹
            _mutuallyExclusiveGroups.Add("알파룸", new List<string> { "8-1", "8-2" });
            _constraints.Add("A", new List<string> { "8-1", "8-2" }); // A 선택시 8-1, 8-2 선택 불가

            // 조명특화 상호배타적 그룹
            _mutuallyExclusiveGroups.Add("조명특화", new List<string> { "13-1", "13-2" });

            // 주방가전 상호배타적 그룹
            _mutuallyExclusiveGroups.Add("주방가전", new List<string> { "14-1", "14-2" });

            // 시스템에어컨 상호배타적 그룹
            _mutuallyExclusiveGroups.Add("시스템에어컨", new List<string> { "15-1", "15-2", "15-3", "15-4" });
            _prerequisites.Add("15-2", new List<string> { "8-1", "8-2" });  // 15-2는 8-1 또는 8-2가 선택되어야 함
            _prerequisites.Add("15-3", new List<string> { "A" });           // 15-3은 A가 선택되어야 함
        }

        public void OptionSelected(string optionCode, bool isSelected)
        {
            if (isSelected)
            {
                // 제약조건 체크 및 적용
                if (_constraints.ContainsKey(optionCode))
                {
                    foreach (var constrainedOption in _constraints[optionCode])
                    {
                        _selectedOptions.Remove(constrainedOption);
                    }
                }

                // 상호배타적 그룹 체크
                foreach (var group in _mutuallyExclusiveGroups)
                {
                    if (group.Value.Contains(optionCode))
                    {
                        foreach (var option in group.Value)
                        {
                            if (option != optionCode)
                            {
                                _selectedOptions.Remove(option);
                            }
                        }
                    }
                }

                _selectedOptions.Add(optionCode);
            }
            else
            {
                _selectedOptions.Remove(optionCode);
            }
        }

        public bool CanSelectOption(string optionCode)
        {
            // 이미 선택된 옵션이면 true 반환
            if (_selectedOptions.Contains(optionCode))
                return true;

            // 제약조건 체크
            foreach (var selectedOption in _selectedOptions)
            {
                if (_constraints.ContainsKey(selectedOption) &&
                    _constraints[selectedOption].Contains(optionCode))
                {
                    return false;
                }
            }

            // 선행조건 체크
            if (_prerequisites.ContainsKey(optionCode))
            {
                bool hasPrerequisite = false;
                foreach (var prereq in _prerequisites[optionCode])
                {
                    if (_selectedOptions.Contains(prereq))
                    {
                        hasPrerequisite = true;
                        break;
                    }
                }
                if (!hasPrerequisite) 
                    return false;
            }

            // 상호배타적 그룹 체크
            foreach (var group in _mutuallyExclusiveGroups)
            {
                if (group.Value.Contains(optionCode))
                {
                    foreach (var option in group.Value)
                    {
                        if (option != optionCode && _selectedOptions.Contains(option))
                            return false;
                    }
                }
            }

            return true;
        }
    }

    public class OptionItemViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private bool _isSelected;
        private bool _isEnabled = true;

        public string Code { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DownPayment { get; set; }
        public decimal Interim { get; set; }
        public decimal Balance { get; set; }
        public string SelectionConstraintMessage  { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}